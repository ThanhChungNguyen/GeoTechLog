using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using System;
using GeoTechLog.Reports;

namespace GeoTechLog.Web.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly IReportAppService _reportAppService;

        public IndexModel(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }

        public PagedResultDto<ReportListDto> Reports { get; set; }

        public async Task OnGetAsync()
        {
            var input = new GetReportsInput
            {
                MaxResultCount = 20,
                SkipCount = 0
            };

            Reports = await _reportAppService.GetListAsync(input);
        }
    }
}
