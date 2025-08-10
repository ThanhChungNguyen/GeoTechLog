using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using GeoTechLog.Reports;
using System;

namespace GeoTechLog.Web.Pages.Reports
{
    public class EditModalModel : PageModel
    {
        private readonly IReportAppService _reportAppService;

        public EditModalModel(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }

        [BindProperty]
        public ReportDetailDto Report { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            id = new Guid("b5e5638e-4cd3-9f78-576a-3a1ba4b09799");
            Report = await _reportAppService.GetAsync(id);
            if (Report == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updateReportDto = new UpdateReportDto {
                Title = Report.Title,
                ReportTypeId = Report.ReportTypeId
            };
     
            await _reportAppService.UpdateAsync(Report.Id, updateReportDto);
            return new JsonResult(new { success = true });
        }
    }
}
