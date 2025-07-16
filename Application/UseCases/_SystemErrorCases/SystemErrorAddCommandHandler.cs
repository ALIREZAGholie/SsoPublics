using Application.IRepositories.ISystemErrorRepositories;
using FluentValidation;
using Webgostar.Framework.Application.QueryCommandTools;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases._SystemErrorCases
{
    public class SystemErrorAddCommand : ICommand<bool>
    {
        public string Test { get; set; }
    }

    public class SystemErrorAddValidator : AbstractValidator<SystemErrorAddCommand>
    {
        public SystemErrorAddValidator()
        {
            RuleFor(x => x.Test)
                .NotNull().WithMessage("تست را وارد کنید")
                .NotEmpty().WithMessage("تست را وارد کنید");
        }
    }

    public class SystemErrorAddHandler(ISystemErrorRepository errorRepository, IUnitOfWork unitOfWork) : ICommandHandler<SystemErrorAddCommand, bool>
    {
        public async Task<OperationResult<bool>> Handle(SystemErrorAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new SystemError(request.Test);

                await errorRepository.Add(entity, cancellationToken);

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
