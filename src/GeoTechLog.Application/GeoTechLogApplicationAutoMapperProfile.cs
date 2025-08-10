using AutoMapper;
using GeoTechLog.Reports;

namespace GeoTechLog;

public class GeoTechLogApplicationAutoMapperProfile : Profile
{
    public GeoTechLogApplicationAutoMapperProfile()
    {

        CreateMap<Report, ReportDetailDto>();
        CreateMap<ReportVersion, ReportVersionDto>();
        CreateMap<Report, ReportListDto>();
        CreateMap<ReportAttachment, ReportAttachmentDto>();
        CreateMap<ReportType, ReportTypeDto>();
        CreateMap<Borehole, BoreholeDto>();
    }
}
