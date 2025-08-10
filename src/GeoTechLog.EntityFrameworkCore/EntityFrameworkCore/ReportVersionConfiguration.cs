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
    public class ReportVersionConfiguration : IEntityTypeConfiguration<ReportVersion>
    {
        public void Configure(EntityTypeBuilder<ReportVersion> b)
        {
            b.ToTable("Geo_ReportVersions");
            b.HasKey(x => x.Id);
            b.Property(x => x.VersionNumber).IsRequired();
            b.Property(x => x.ContentJson).HasColumnType("nvarchar(max)");
            b.HasIndex(x => new { x.ReportId, x.VersionNumber }).IsUnique();
        }
    }
}
