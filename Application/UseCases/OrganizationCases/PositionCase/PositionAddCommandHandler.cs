using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.PositionEntity;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.OrganizationCases.PositionCase
{
    public class PositionAddCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class PositionAddValidator : AbstractValidator<PositionAddCommand>
    {
        public PositionAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("وارد کردن نام الزامی است")
                .NotNull().WithMessage("وارد کردن نام الزامی است");
        }
    }

    public class PositionAddHandler : ICommandHandler<PositionAddCommand, bool>
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionAddHandler(IPositionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(PositionAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = new Position(request.Name, request.Description);

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
