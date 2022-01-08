using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UploadScorm.Core.Data;
using UploadScorm.Core.DTO;
using UploadScorm.Core.Service;

namespace UploadScorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesDataController : ControllerBase
    {
        private readonly IFilesDataService filesDataService;
        public FilesDataController(IFilesDataService filesDataService)
        {
            this.filesDataService = filesDataService;
        }
        [ProducesResponseType(typeof(List<FilesData>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FilesData), StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("GetFilesData")]
        public List<FilesData> GetFilesData()
        {
            return filesDataService.GetFilesData();
        }
        [ProducesResponseType(typeof(List<FilesData>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FilesData), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("InsertFilesData")]
        public bool InsertFilesData([FromBody] FilesData filesData)
        {
            return filesDataService.InsertFilesData(filesData);
        }
        [ProducesResponseType(typeof(List<FilesData>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FilesData), StatusCodes.Status400BadRequest)]
        [Route("UplodZIP/{versionId}")]
        [HttpPost]
        public TaskResult UplodZIP(int versionId)
        {
            string myPath = @"C:\Users\User\Downloads\UploadScorm\UploadScorm.API\ScormFiles\";
            TaskResult result = new TaskResult();
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileContent = ms.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                //decoder for image name , no duplicate errors
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                //path for angualr project file C:\\Users\\User\\source\\repos\\WebApplication2\\Core\\ScormFiles\\
                var fullPath = Path.Combine(myPath, attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // string startPath = @"c:\example\start";
                string zipPath = Path.Combine(myPath, attachmentFileName);
              
                var extractPath = Path.Combine(@"C:\Users\User\Downloads\UploadScorm\UploadScorm.API\Extracted Scorm FIles\", attachmentFileName);



                ZipFile.ExtractToDirectory(zipPath, extractPath);

                result.result = true;
                result.description = "Task Completed Succesfully";


                FilesData fileZIP = new FilesData();
                fileZIP.name = attachmentFileName;
                fileZIP.versionId = versionId;

                filesDataService.InsertFilesData(fileZIP);

                return result;
            }
            catch (Exception e)
            {
                result.result = false;
                result.description = e.Message;
                return result;
            }
        }
    }
}