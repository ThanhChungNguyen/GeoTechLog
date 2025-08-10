using System;
using GeoTechLog.Reports;
using Volo.Abp.Application.Dtos;

public class GetReportsInput : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; } // text filter on title
    public Guid? ReportTypeId { get; set; }
    public ReportStatus? Status { get; set; }
    public DateTimeOffset? CreatedFrom { get; set; }
    public DateTimeOffset? CreatedTo { get; set; }
}