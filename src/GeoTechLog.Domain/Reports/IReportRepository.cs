using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GeoTechLog.Reports
{
    public interface IReportRepository : IRepository<Report, Guid>
    {
        Task<List<Report>> GetListWithDetailsAsync(
            string? filter,
            Guid? reportTypeId,
            ReportStatus? status,
            DateTimeOffset? createdFrom,
            DateTimeOffset? createdTo,
            int skipCount,
            int maxResultCount);

        Task<int> GetCountAsync(
            string? filter,
            Guid? reportTypeId,
            ReportStatus? status,
            DateTimeOffset? createdFrom,
            DateTimeOffset? createdTo);

        Task<Report?> GetWithDetailsAsync(Guid id);
    }
}
