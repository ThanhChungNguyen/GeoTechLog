using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GeoTechLog.Reports
{
    public interface IReportVersionRepository : IRepository<ReportVersion, Guid>
    {
        Task<List<ReportVersion>> GetVersionsAsync(Guid reportId);
    }
}