using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GeoTechLog.Reports
{
    public class ReportAttachment : Entity<Guid>
    {
        public Guid ReportVersionId { get; set; }
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long Size { get; set; }
        public string StoragePath { get; set; } = null!;    // e.g. blob key or FS path
        public virtual ReportVersion ReportVersion { get; set; } = null!;
    }

}
