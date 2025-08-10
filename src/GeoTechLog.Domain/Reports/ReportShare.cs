using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GeoTechLog.Reports
{
    public class ReportShare : Entity<Guid>
    {
        public Guid ReportId { get; set; }
        public string ExternalEmail { get; set; } = null!;
        public string ShareToken { get; set; } = null!;     // random token for link
        public DateTimeOffset ExpiresAt { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual Report Report { get; set; } = null!;
    }

}
