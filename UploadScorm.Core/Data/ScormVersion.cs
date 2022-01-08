using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UploadScorm.Core.Data
{
    public class ScormVersion
    {
        [Key]
        public int Id { get; set; }
        public string Version { get; set; }
        public virtual ICollection<FilesData> FilesData { get; set; }
    }
}
