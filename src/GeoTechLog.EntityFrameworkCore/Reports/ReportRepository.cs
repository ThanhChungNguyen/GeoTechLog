using GeoTechLog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GeoTechLog.Reports
{
    public class ReportRepository : EfCoreRepository<GeoTechLogDbContext, Report, Guid>, IReportRepository
    {
        public ReportRepository(IDbContextProvider<GeoTechLogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Report>> GetListWithDetailsAsync(
            string? filter,
            Guid? reportTypeId,
            ReportStatus? status,
            DateTimeOffset? createdFrom,
            DateTimeOffset? createdTo,
            int skipCount,
            int maxResultCount)
        {
            var query = await GetQueryableAsync();

            query = query.Include(r => r.ReportType)
                         .Include(r => r.CurrentVersion);

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(r => r.Title.Contains(filter));

            if (reportTypeId.HasValue)
                query = query.Where(r => r.ReportTypeId == reportTypeId.Value);

            if (status.HasValue)
                query = query.Where(r => r.Status == status.Value);

            if (createdFrom.HasValue)
                query = query.Where(r => r.CreationTime >= createdFrom.Value);

            if (createdTo.HasValue)
                query = query.Where(r => r.CreationTime <= createdTo.Value);

            return await query.OrderByDescending(r => r.CreationTime)
                              .Skip(skipCount)
                              .Take(maxResultCount)
                              .ToListAsync();
        }

        public async Task<int> GetCountAsync(
            string? filter,
            Guid? reportTypeId,
            ReportStatus? status,
            DateTimeOffset? createdFrom,
            DateTimeOffset? createdTo)
        {
            var query = await GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(r => r.Title.Contains(filter));

            if (reportTypeId.HasValue)
                query = query.Where(r => r.ReportTypeId == reportTypeId.Value);

            if (status.HasValue)
                query = query.Where(r => r.Status == status.Value);

            if (createdFrom.HasValue)
                query = query.Where(r => r.CreationTime >= createdFrom.Value);

            if (createdTo.HasValue)
                query = query.Where(r => r.CreationTime <= createdTo.Value);

            return await query.CountAsync();
        }

        public async Task<Report?> GetWithDetailsAsync(Guid id)
        {
            var query = await GetQueryableAsync();

            return await query
                .Include(r => r.ReportType)
                .Include(r => r.CurrentVersion)
                .Include(r => r.Versions)
                .Include(r => r.ReportBoreholes)
                .ThenInclude(rb => rb.Borehole)
                .Include(r => r.Shares)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
