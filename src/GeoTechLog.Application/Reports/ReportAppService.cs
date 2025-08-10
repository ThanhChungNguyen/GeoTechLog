using AutoMapper.Internal.Mappers;
using GeoTechLog.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace GeoTechLog.Reports
{
    public class ReportAppService : ApplicationService, IReportAppService
    {
        private readonly IReportRepository _reportRepo;
        private readonly IReportVersionRepository _reportVersionRepo;
        private readonly IRepository<ReportAttachment, Guid> _attachRepo;
        private readonly  IBlobContainer<ReportsContainer> _blobContainer;

        public ReportAppService(IReportRepository reportRepo,
            IReportVersionRepository reportVersionRepo,
            IRepository<ReportAttachment, Guid> attachRepo,
             IBlobContainer<ReportsContainer> blobContainer)
        {
            _reportRepo = reportRepo;
            _reportVersionRepo = reportVersionRepo;
            _attachRepo = attachRepo;
            _blobContainer = blobContainer;
        }

        public async Task<PagedResultDto<ReportListDto>> GetListAsync(GetReportsInput input)
        {
            var totalCount = await _reportRepo.GetCountAsync(
                input.Filter,
                input.ReportTypeId,
                input.Status,
                input.CreatedFrom,
                input.CreatedTo);

            var list = await _reportRepo.GetListWithDetailsAsync(
                input.Filter,
                input.ReportTypeId,
                input.Status,
                input.CreatedFrom,
                input.CreatedTo,
                input.SkipCount,
                input.MaxResultCount);

            var dtoList = ObjectMapper.Map<List<Report>, List<ReportListDto>>(list);
            return new PagedResultDto<ReportListDto>(totalCount, dtoList);
        }

        public async Task<ReportDetailDto> GetAsync(Guid id)
        {
            var report = await _reportRepo.GetWithDetailsAsync(id);
            if (report == null)
                throw new EntityNotFoundException(typeof(Report), id);

            return ObjectMapper.Map<Report, ReportDetailDto>(report);
        }

        [UnitOfWork]
        public async Task<ReportDetailDto> CreateAsync(CreateReportDto input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            var report = new Report
            {
                Title = input.Title,
                ReportTypeId = input.ReportTypeId,
                Status = ReportStatus.Draft,
                IsSharedExternally = false
            };

            await _reportRepo.InsertAsync(report, autoSave: true);

            var version = new ReportVersion
            {
                ReportId = report.Id,
                VersionNumber = 1,
                Summary = input.Summary ?? string.Empty,
                ContentJson = input.ContentJson ?? "{}",
                CreatedAt = Clock.Now,
                CreatedBy = CurrentUser.Id ?? Guid.Empty
            };

            await _reportVersionRepo.InsertAsync(version, autoSave: true);
            report.CurrentVersionId = version.Id;
            report.Versions.Add(version);

            if (input.BoreholeIds != null && input.BoreholeIds.Any())
            {
                foreach (var boreholeId in input.BoreholeIds)
                {
                    report.ReportBoreholes.Add(new ReportBorehole
                    {
                        ReportId = report.Id,
                        BoreholeId = boreholeId
                    });
                }
            }

            await _reportRepo.UpdateAsync(report, autoSave: true);

            return ObjectMapper.Map<Report, ReportDetailDto>(report);
        }

        public async Task<ReportDetailDto> UpdateAsync(Guid id, UpdateReportDto input)
        {
            var report = await _reportRepo.GetWithDetailsAsync(id);
            if (report == null)
                throw new EntityNotFoundException(typeof(Report), id);

            report.Title = input.Title;
            report.ReportTypeId = input.ReportTypeId;
            report.Status = input.Status;

            // Tạo version mới nếu nội dung thay đổi
            var lastVersionNumber = report.Versions.Max(v => v.VersionNumber);
            var newVersion = new ReportVersion
            {
                ReportId = id,
                VersionNumber = lastVersionNumber + 1,
                Summary = input.Summary ?? string.Empty,
                ContentJson = input.ContentJson ?? "{}",
                CreatedAt = Clock.Now,
                CreatedBy = CurrentUser.Id ?? Guid.Empty
            };

            await _reportVersionRepo.InsertAsync(newVersion);

            report.CurrentVersionId = newVersion.Id;
            report.Versions.Add(newVersion);

            if (input.BoreholeIds != null)
            {
                report.ReportBoreholes.Clear();

                foreach (var boreholeId in input.BoreholeIds)
                {
                    report.ReportBoreholes.Add(new ReportBorehole
                    {
                        ReportId = id,
                        BoreholeId = boreholeId
                    });
                }
            }

            await _reportRepo.UpdateAsync(report);

            return ObjectMapper.Map<Report, ReportDetailDto>(report);
        }

        public async Task DeleteAsync(Guid id)
        {
            var report = await _reportRepo.GetAsync(id);
            if (report == null)
                throw new EntityNotFoundException(typeof(Report), id);

            await _reportRepo.DeleteAsync(report);
        }

        public async Task<ReportAttachmentDto> UploadAttachmentAsync(Guid id, FileUploadDto file)
        {
            var report = await _reportRepo.GetAsync(id);
            if (report.CurrentVersionId == null)
                throw new UserFriendlyException("Report has no version.");

            var key = $"reports/{id}/{Guid.NewGuid()}-{file.FileName}";
            using (var ms = new MemoryStream(file.Content))
            {
                await _blobContainer.SaveAsync(key, ms);
            }

            var attach = new ReportAttachment
            {
                ReportVersionId = report.CurrentVersionId.Value,
                FileName = file.FileName,
                ContentType = file.ContentType ?? "application/octet-stream",
                Size = file.Length,
                StoragePath = key
            };
            await _attachRepo.InsertAsync(attach);

            return ObjectMapper.Map<ReportAttachment, ReportAttachmentDto>(attach);
        }

        public async Task ApproveAsync(Guid id)
        {
            var r = await _reportRepo.GetAsync(id);
            if (r.Status != ReportStatus.Review)
                throw new UserFriendlyException("Report must be in Review state to approve.");

            r.Status = ReportStatus.Approved;
            await _reportRepo.UpdateAsync(r);
        }

        public async Task<List<ReportVersionDto>> GetHistoryAsync(Guid reportId)
        {
            var versions = await _reportVersionRepo.GetVersionsAsync(reportId);
            return ObjectMapper.Map<List<ReportVersion>, List<ReportVersionDto>>(versions);
        }
    }
}
