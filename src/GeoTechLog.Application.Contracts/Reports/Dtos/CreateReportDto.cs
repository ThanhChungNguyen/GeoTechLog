using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace GeoTechLog.Reports
{
    public class CreateReportDto
    {
        [Required, MaxLength(250)]
        public string Title { get; set; } = null!;
        [Required]
        public Guid ReportTypeId { get; set; }
        public List<Guid> BoreholeIds { get; set; } = new();
        [MaxLength(1000)]
        public string? Summary { get; set; }
        public string? ContentJson { get; set; }
    }
}
