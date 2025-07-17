using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.AuthCases.UserCase.Edit
{
    public class UserEditCommand : ICommand<bool>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserEditValidator : AbstractValidator<UserEditCommand>
    {
        public UserEditValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("نام را وارد کنید")
                .NotEmpty().WithMessage("نام را وارد کنید");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("نام خانوادگی را وارد کنید")
                .NotEmpty().WithMessage("نام خانوادگی را وارد کنید");
        }
    }

    public class UserEditHandler : ICommandHandler<UserEditCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserEditHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(UserEditCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _repository.UserManager.FindByIdAsync(request.Id);

                user.Edit(request.FirstName, request.LastName);

                await _repository.UserManager.UpdateAsync(user);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Error(e.Message);
            }
        }
    }
}
