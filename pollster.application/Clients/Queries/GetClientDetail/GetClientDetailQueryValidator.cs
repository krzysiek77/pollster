using FluentValidation;

namespace pollster.application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQueryValidator : AbstractValidator<GetClientDetailQuery>
    {
        public GetClientDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}