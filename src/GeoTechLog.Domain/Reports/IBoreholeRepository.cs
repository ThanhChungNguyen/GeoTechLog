using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GeoTechLog.Reports
{
    public interface IBoreholeRepository : IRepository<Borehole, Guid>
    {
        Task<List<Borehole>> GetListAsync();
    }
}
