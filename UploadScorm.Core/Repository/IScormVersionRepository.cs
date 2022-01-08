using System;
using System.Collections.Generic;
using System.Text;
using UploadScorm.Core.Data;

namespace UploadScorm.Core.Repository
{
    public interface IScormVersionRepository
    {
        public List<ScormVersion> GetScormVersion();
    }
}
