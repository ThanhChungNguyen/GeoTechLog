using GeoTechLog.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTechLog.EntityFrameworkCore
{
    public class ReportBoreholeConfiguration : IEntityTypeConfiguration<ReportBorehole>
    {
        public void Configure(EntityTypeBuilder<ReportBorehole> b)
        {
            b.ToTable("Geo_ReportBoreholes");
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.ReportId, x.BoreholeId }).IsUnique();
            b.HasOne(x => x.Report).WithMany(r => r.ReportBoreholes).HasForeignKey(x => x.ReportId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Borehole).WithMany().HasForeignKey(x => x.BoreholeId).OnDelete(DeleteBehavior.Restrict);
        }
    }

}
