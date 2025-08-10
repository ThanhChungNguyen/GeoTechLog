using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace GeoTechLog.Reports
{
    // ReportListDto.cs
    public class ReportListDto : EntityDto<Guid>
    {
        public string Title { get; set; } = null!;
        public GeoTechLog.Reports.ReportStatus Status { get; set; }
        public string ReportTypeName { get; set; } = null!;
        public DateTimeOffset CreationTime { get; set; }
    }

    // ReportDetailDto.cs
    public class ReportDetailDto : EntityDto<Guid>
    {
        public string Title { get; set; } = null!;
        public ReportStatus Status { get; set; }
        public Guid ReportTypeId { get; set; }
        public int CurrentVersionNumber { get; set; }
        public ReportVersionDto? CurrentVersion { get; set; }
        public List<Guid> BoreholeIds { get; set; } = new();
    }

    // ReportVersionDto.cs
    public class ReportVersionDto : EntityDto<Guid>
    {
        public int VersionNumber { get; set; }
        public string Summary { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public List<ReportAttachmentDto> Attachments { get; set; } = new();
    }

    // ReportAttachmentDto
    public class ReportAttachmentDto : EntityDto<Guid>
    {
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long Size { get; set; }
        public string DownloadUrl { get; set; } = null!;
    }
}
