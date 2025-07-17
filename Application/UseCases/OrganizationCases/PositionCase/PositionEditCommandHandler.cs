using Application.IRepositories.IOrganization;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.OrganizationCases.PositionCase
{
    public class PositionEditCommand : ICommand<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class PositionEditValidator : AbstractValidator<PositionEditCommand>
    {
        public PositionEditValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("اطلاعات به درستی ارسال نشده است")
                .NotNull().WithMessage("اطلاعات به درستی ارسال نشده است");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("وارد کردن نام الزامی است")
                .NotNull().WithMessage("وارد کردن نام الزامی است");
        }
    }

    public class PositionEditHandler : ICommandHandler<PositionEditCommand, bool>
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionEditHandler(IPositionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(PositionEditCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repository.GetByIdAsync(request.Id, cancellationToken);

                model.Edit(request.Name, request.Description);

                await _repository.Update(model);
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
