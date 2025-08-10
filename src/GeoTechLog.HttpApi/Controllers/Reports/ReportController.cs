using GeoTechLog.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GeoTechLog.Controllers.Reports
{
    [Route("api/reports")]
    public class ReportsController : GeoTechLogController
    {
        private readonly IReportAppService _reportAppService;

        public ReportsController(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }

        // GET /api/reports
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetReportsInput input)
        {
            var result = await _reportAppService.GetListAsync(input);
            return Ok(result);
        }

        // GET /api/reports/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _reportAppService.GetAsync(id);
            return Ok(result);
        }

        // POST /api/reports
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportDto input)
        {
            var result = await _reportAppService.CreateAsync(input);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT /api/reports/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReportDto input)
        {
            var result = await _reportAppService.UpdateAsync(id, input);
            return Ok(result);
        }

        // DELETE /api/reports/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reportAppService.DeleteAsync(id);
            return NoContent();
        }

        // POST /api/reports/{id}/attachments
        [HttpPost("{id}/attachments")]
        public async Task<IActionResult> UploadAttachment(Guid id, [FromForm] UploadReportAttachmentFormDto input)
        {
            using var ms = new MemoryStream();
            await input.File.CopyToAsync(ms);

            var dto = new FileUploadDto
            {
                FileName = input.File.FileName,
                ContentType = input.File.ContentType,
                Length = input.File.Length,
                Content = ms.ToArray()
            };

            await _reportAppService.UploadAttachmentAsync(id, dto);
            return Ok();
        }

        // POST /api/reports/{id}/approve
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(Guid id)
        {
            await _reportAppService.ApproveAsync(id);
            return NoContent();
        }

        // GET /api/reports/{id}/history
        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetHistory(Guid id)
        {
            var result = await _reportAppService.GetHistoryAsync(id);
            return Ok(result);
        }
    }
}
