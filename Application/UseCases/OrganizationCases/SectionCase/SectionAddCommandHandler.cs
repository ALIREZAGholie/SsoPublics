using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.SectionEntity;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.OrganizationCases.SectionCase
{
    public class SectionAddCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class SectionAddValidator : AbstractValidator<SectionAddCommand>
    {
        public SectionAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("وارد کردن نام الزامی است")
                .NotNull().WithMessage("وارد کردن نام الزامی است");
        }
    }

    public class SectionAddHandler : ICommandHandler<SectionAddCommand, bool>
    {
        private readonly ISectionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SectionAddHandler(ISectionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(SectionAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = new Section(request.Name, request.Description);

                await _repository.Add(model, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
