using System;
using System.Collections.Generic;
using System.Text;
using UploadScorm.Core.Data;

namespace UploadScorm.Core.Service
{
    public interface IScormVersionService
    {
        public List<ScormVersion> GetScormVersion();
    }
}
