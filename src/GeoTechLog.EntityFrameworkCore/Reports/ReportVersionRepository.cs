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
    public class ReportVersionRepository
    : EfCoreRepository<GeoTechLogDbContext, ReportVersion, Guid>, IReportVersionRepository
    {
        public ReportVersionRepository(IDbContextProvider<GeoTechLogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ReportVersion>> GetVersionsAsync(Guid reportId)
        {
            return await (await GetDbSetAsync())
                .Where(v => v.ReportId == reportId)
                .OrderByDescending(v => v.VersionNumber)
                .ToListAsync();
        }
    }
}