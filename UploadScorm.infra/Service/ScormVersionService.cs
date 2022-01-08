using System;
using System.Collections.Generic;
using System.Text;
using UploadScorm.Core.Data;
using UploadScorm.Core.Repository;
using UploadScorm.Core.Service;

namespace UploadScorm.infra.Service
{
    public class ScormVersionService : IScormVersionService
    {
        private readonly IScormVersionRepository scormVersionRepository;
        public ScormVersionService(IScormVersionRepository scormVersionRepository)
        {
            this.scormVersionRepository = scormVersionRepository;
        }

        public List<ScormVersion> GetScormVersion()
        {
            return scormVersionRepository.GetScormVersion();
        }
    }
}
