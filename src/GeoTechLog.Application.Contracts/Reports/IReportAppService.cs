using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GeoTechLog.Reports
{
    public interface IReportAppService : IApplicationService
    {
        Task<PagedResultDto<ReportListDto>> GetListAsync(GetReportsInput input);
        Task<ReportDetailDto> GetAsync(Guid id);
        Task<ReportDetailDto> CreateAsync(CreateReportDto input);
        Task<ReportDetailDto> UpdateAsync(Guid id, UpdateReportDto input);
        Task DeleteAsync(Guid id);
        Task<ReportAttachmentDto> UploadAttachmentAsync(Guid id, FileUploadDto file);
        Task ApproveAsync(Guid id);
        Task<List<ReportVersionDto>> GetHistoryAsync(Guid id);
        Task<List<ReportTypeDto>> GetReportTypesAsync();
        Task<List<BoreholeDto>> GetBoreholesAsync();
    }

}
