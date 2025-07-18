using Application.IRepositories.IUserRepositories;
using Application.UseCases._ApplicationUseCaseException.UserException;
using Domain._DomainValueObjects;
using Domain.UserAgg.UserEntity;
using Domain.UserAgg.UserEntity.Services;
using FluentValidation;
using Microsoft.Extensions.Options;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;
using Webgostar.Framework.Domain.ValueObjects.Auth;

namespace Application.UseCases.AuthCases.AuthCase
{
    public class RegisterUserCommand : ICommand<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("نام را وارد کنید")
                .NotEmpty().WithMessage("نام را وارد کنید");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("نام خانوادگی را وارد کنید")
                .NotEmpty().WithMessage("نام خانوادگی را وارد کنید");
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("شماره تماس را وارد کنید")
                .NotEmpty().WithMessage("نام کاربر را وارد کنید");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("رمز عبور را وارد کنید")
                .NotEmpty().WithMessage("رمز عبور را وارد کنید");
            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithMessage("تائید رمز عبور را وارد کنید")
                .NotEmpty().WithMessage("تائید رمز عبور را وارد کنید");
        }
    }

    public class RegisterUserHandler : ICommandHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDomainService _userDomainService;
        private readonly AuthPasswordOptions _options;

        public RegisterUserHandler(IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IUserDomainService userDomainService,
            IOptions<AuthPasswordOptions> options)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userDomainService = userDomainService;
            _options = options.Value;
        }

        public async Task<OperationResult<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                if (request.Password != request.ConfirmPassword)
                {
                    throw new InvalidConfirmPasswordException();
                }

                User user = new(request.FirstName, request.LastName, request.UserName,
                    new Password(request.Password, _options), _userDomainService);

                await _userRepository.Add(user, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}
