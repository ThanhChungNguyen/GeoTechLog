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
    public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> b)
        {
            b.ToTable("Geo_Reports");
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).HasMaxLength(250).IsRequired();
            b.HasOne(x => x.CurrentVersion).WithMany().HasForeignKey(x => x.CurrentVersionId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.ReportType).WithMany().HasForeignKey(x => x.ReportTypeId).OnDelete(DeleteBehavior.Restrict);
            b.HasIndex(x => x.ReportTypeId);
            b.HasIndex(x => x.Status);
        }
    }

}
