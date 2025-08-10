using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GeoTechLog.Reports
{
    public class Report : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; } = null!;
        public Guid? CurrentVersionId { get; set; }    // FK to ReportVersion (nullable before first save)
        public ReportStatus Status { get; set; } = ReportStatus.Draft;
        public Guid ReportTypeId { get; set; }         // FK to ReportType for flexibility
        public bool IsSharedExternally { get; set; }

        // navigation
        public virtual ReportVersion? CurrentVersion { get; set; }
        public virtual ReportType ReportType { get; set; } = null!;
        public virtual ICollection<ReportBorehole> ReportBoreholes { get; set; } = new List<ReportBorehole>();
        public virtual ICollection<ReportShare> Shares { get; set; } = new List<ReportShare>();
        public virtual ICollection<ReportVersion> Versions { get; set; } = new List<ReportVersion>();
    }
}
