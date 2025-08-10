using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GeoTechLog.Reports
{
    public class ReportVersion : Entity<Guid>
    {
        public Guid ReportId { get; set; }
        public int VersionNumber { get; set; }              // 1,2,3...
        public string Summary { get; set; } = string.Empty; // small desc
        public string ContentJson { get; set; } = "{}";     // serialized payload if desired
        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        // attachments metadata
        public virtual ICollection<ReportAttachment> Attachments { get; set; } = new List<ReportAttachment>();
        public virtual Report Report { get; set; } = null!;
    }

}
