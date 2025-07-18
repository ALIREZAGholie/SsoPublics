using Application._ApplicationException;
using Application.IRepositories.IRoleRepositories;
using Domain.RoleAgg.RoleEntity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.AuthCases.RoleCase.Add
{
    public class RoleAddCommand : ICommand<bool>
    {
        public long ParentId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public bool AccessAll { get; set; }
        public bool AccessAllEmploye { get; set; }
        public DateTime? RoleExpireDate { get; set; }
        public long MemberShipTypeId { get; set; }
    }

    public class RoleAddValidator : AbstractValidator<RoleAddCommand>
    {
        public RoleAddValidator()
        {
            RuleFor(x => x.ParentId)
                .NotNull().WithMessage("نقش پایه را انتخاب کنید");
            RuleFor(x => x.CompanyId)
                .NotNull().WithMessage("شرکت نقش را انخاب کنید");
            RuleFor(x => x.Name)
                .NotNull().WithMessage("نام نقش را وارد کنید");
            RuleFor(x => x.MemberShipTypeId)
                .NotNull().WithMessage("نوع عضوبت را انتخاب کنید")
                .NotEqual(0).WithMessage("نوع عضوبت را انتخاب کنید")
                .NotEmpty().WithMessage("نوع عضوبت را انتخاب کنید");
        }
    }

    public class RoleAddHandler : ICommandHandler<RoleAddCommand, bool>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleAddHandler(IRoleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(RoleAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                Role role = new(request.Name, request.ParentId, request.CompanyId,
                    request.AccessAll, request.AccessAllEmploye, request.RoleExpireDate);

                await _repository.Add(role, cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);
                return OperationResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                return OperationResult<bool>.Error(e.Message);
            }
        }
    }
}
