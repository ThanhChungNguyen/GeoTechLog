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
    public class ReportAttachmentConfiguration : IEntityTypeConfiguration<ReportAttachment>
    {
        public void Configure(EntityTypeBuilder<ReportAttachment> b)
        {
            b.ToTable("Geo_ReportAttachments");
            b.HasKey(x => x.Id);
            b.Property(x => x.FileName).HasMaxLength(260);
            b.Property(x => x.StoragePath).IsRequired();
            b.HasIndex(x => x.ReportVersionId);
        }
    }

}
