using FluentValidation;
using GeoTechLog.Reports;

public class UpdateReportDtoValidator : AbstractValidator<UpdateReportDto>
{
    public UpdateReportDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(x => x.ReportTypeId)
            .NotEmpty();

        RuleFor(x => x.Summary)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Summary));

        RuleFor(x => x.BoreholeIds)
            .NotNull()
            .ForEach(idRule => idRule.NotEmpty());
    }
}
    