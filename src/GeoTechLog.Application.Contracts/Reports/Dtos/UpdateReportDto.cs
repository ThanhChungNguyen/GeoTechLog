using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace GeoTechLog.Reports
{
    public class UpdateReportDto
    {
        public string Title { get; set; } = null!;
        public Guid ReportTypeId { get; set; }
        public ReportStatus Status { get; set; }
        public string? Summary { get; set; }
        public string? ContentJson { get; set; }
        public List<Guid>? BoreholeIds { get; set; }
    }
}
