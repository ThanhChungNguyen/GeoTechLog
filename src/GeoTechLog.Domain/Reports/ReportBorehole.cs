using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GeoTechLog.Reports
{
    public class ReportBorehole : Entity<Guid>
    {
        public Guid ReportId { get; set; }
        public Guid BoreholeId { get; set; }

        public virtual Report Report { get; set; } = null!;
        public virtual Borehole Borehole { get; set; } = null!;
    }
}
