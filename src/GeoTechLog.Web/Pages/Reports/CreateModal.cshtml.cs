using GeoTechLog.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GeoTechLog.Web.Pages.Reports
{
    public class CreateModalModel : PageModel
    {
        private readonly IReportAppService _reportAppService;

        public CreateModalModel(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100)]
            public string Title { get; set; }

            [Required]
            public Guid ReportTypeId { get; set; }

            [Required]
            public List<Guid> BoreholeIds { get; set; }

            [StringLength(500)]
            public string Summary { get; set; }

            public string ContentJson { get; set; }
        }


        public async Task OnGet()
        {
            var reportType = await _reportAppService.GetReportTypesAsync();
            var boreholes = await _reportAppService.GetBoreholesAsync();
            // TODO: prepare reportType & Borehole to allow select
        }
    }
}
