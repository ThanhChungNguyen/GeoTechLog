using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GeoTechLog.Reports
{
    public interface IReportTypeRepository : IRepository<ReportType, Guid>
    {
        Task<List<ReportType>> GetListAsync();
    }
}
