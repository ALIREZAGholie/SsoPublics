using Application.IRepositories.ISystemErrorRepositories;
using FluentValidation;
using Webgostar.Framework.Application.QueryCommandTools;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases._SystemErrorCases
{
    public class SystemErrorEditCommand : ICommand<bool>
    {
        public long Id { get; set; }
        public string Test { get; set; }
    }

    public class SystemErrorEditValidator : AbstractValidator<SystemErrorEditCommand>
    {
        public SystemErrorEditValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("اطلاعات ارسالی نادرست است.")
                .NotEmpty().WithMessage("اطلاعات ارسالی نادرست است.")
                .NotEqual(0).WithMessage("اطلاعات ارسالی نادرست است.");
            RuleFor(x => x.Test)
                .NotNull().WithMessage("تست را وارد کنید")
                .NotEmpty().WithMessage("تست را وارد کنید");
        }
    }

    public class SystemErrorEditHandler(ISystemErrorRepository errorRepository, IUnitOfWork unitOfWork) : ICommandHandler<SystemErrorEditCommand, bool>
    {
        public async Task<OperationResult<bool>> Handle(SystemErrorEditCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await errorRepository.GetByIdAsync(request.Id, cancellationToken);

                entity.Edit(request.Test);

                await errorRepository.Update(entity);

                await unitOfWork.SaveChangesAsync(cancellationToken);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
