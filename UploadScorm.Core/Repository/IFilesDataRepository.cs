using System;
using System.Collections.Generic;
using System.Text;
using UploadScorm.Core.Data;

namespace UploadScorm.Core.Repository
{
    public interface IFilesDataRepository
    {
        public List<FilesData> GetFilesData();
        public bool InsertFilesData(FilesData FilesData);
    }
}
