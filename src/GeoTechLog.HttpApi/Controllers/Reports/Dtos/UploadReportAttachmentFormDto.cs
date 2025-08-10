using Microsoft.AspNetCore.Http;

namespace GeoTechLog.Controllers.Reports
{
    public class UploadReportAttachmentFormDto
    {
        public IFormFile File { get; set; }
    }
}

