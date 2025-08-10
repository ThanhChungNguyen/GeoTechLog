using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GeoTechLog.Reports
{
    public class Borehole : Entity<Guid>
    {
        public string Name { get; set; }

        // Optional: add only what's necessary for compilation
        public Borehole() { }

        public Borehole(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}
