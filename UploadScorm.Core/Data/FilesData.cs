using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UploadScorm.Core.Data
{
    public class FilesData
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        [ForeignKey("versionId")]
        public int versionId { get; set; }
        public ScormVersion ScormVersion { get; set; }
    }
}
