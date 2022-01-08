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
    public class ScormVersionRepository : IScormVersionRepository
    {
        private readonly IDBContext dBContext;
        public ScormVersionRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<ScormVersion> GetScormVersion()
        {
            IEnumerable<ScormVersion> Result = dBContext.Connection.Query<ScormVersion>("GetScormVersion", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }
    }
}
