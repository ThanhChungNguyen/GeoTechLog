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
    public class BoreholeRepository
    : EfCoreRepository<GeoTechLogDbContext, Borehole, Guid>, IBoreholeRepository
    {
        public BoreholeRepository(IDbContextProvider<GeoTechLogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Borehole>> GetListAsync()
        {
            return await (await GetDbSetAsync())
                .OrderBy(v => v.Name)
                .ToListAsync();
        }
    }
}