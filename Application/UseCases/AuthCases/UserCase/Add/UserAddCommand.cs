using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.AuthCases.UserCase.Add
{
    public class UserAddCommand : ICommand<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserAddValidator : AbstractValidator<UserAddCommand>
    {
        public UserAddValidator()
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

    public class UserAddHandler : ICommandHandler<UserAddCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserAddHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = new(request.FirstName, request.LastName, request.UserName);

                await _repository.UserManager.CreateAsync(user);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
