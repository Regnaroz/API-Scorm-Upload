using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UploadScorm.Core.Common;
using UploadScorm.Core.Data;
using UploadScorm.Core.Repository;


namespace UploadScorm.infra.Repository
{
    public class FilesDataRepository : IFilesDataRepository
    {
        private readonly IDBContext DBContext;
        public FilesDataRepository(IDBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public List<FilesData> GetFilesData()
        {
            IEnumerable<FilesData> Result = DBContext.Connection.Query<FilesData>("GetFilesData", commandType: System.Data.CommandType.StoredProcedure);
            return Result.ToList();
        }

        public bool InsertFilesData(FilesData FilesData)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", FilesData.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@versionId", FilesData.versionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            DBContext.Connection.ExecuteAsync("InsertFilesData", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
