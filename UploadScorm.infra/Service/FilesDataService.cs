using System;
using System.Collections.Generic;
using System.Text;
using UploadScorm.Core.Data;
using UploadScorm.Core.Repository;
using UploadScorm.Core.Service;

namespace UploadScorm.infra.Service
{
    public class FilesDataService : IFilesDataService
    {
        private readonly IFilesDataRepository filesDataRepository;
        public FilesDataService(IFilesDataRepository filesDataRepository)
        {
            this.filesDataRepository = filesDataRepository;
        }

        public List<FilesData> GetFilesData()
        {
            return filesDataRepository.GetFilesData();
        }

        public bool InsertFilesData(FilesData FilesData)
        {
            return filesDataRepository.InsertFilesData(FilesData);
        }
    }
}