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
    public class ReportTypeRepository
    : EfCoreRepository<GeoTechLogDbContext, ReportType, Guid>, IReportTypeRepository
    {
        public ReportTypeRepository(IDbContextProvider<GeoTechLogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ReportType>> GetListAsync()
        {
            return await (await GetDbSetAsync())
                .OrderBy(v => v.Name)
                .ToListAsync();
        }
    }
}