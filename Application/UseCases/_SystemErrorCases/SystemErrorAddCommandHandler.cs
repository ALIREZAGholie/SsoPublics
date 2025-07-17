using FluentValidation;
using Webgostar.Framework.Base.BaseModels;

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

    public class SystemErrorAddHandler() : ICommandHandler<SystemErrorAddCommand, bool>
    {
        public async Task<OperationResult<bool>> Handle(SystemErrorAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
