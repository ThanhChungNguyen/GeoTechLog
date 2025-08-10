using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GeoTechLog.Reports
{
    public class ReportType : Entity<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

}
