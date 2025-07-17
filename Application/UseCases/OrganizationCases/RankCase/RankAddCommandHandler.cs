using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.RankEntity;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.OrganizationCases.RankCase
{
    public class RankAddCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class RankAddValidator : AbstractValidator<RankAddCommand>
    {
        public RankAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("وارد کردن نام الزامی است")
                .NotNull().WithMessage("وارد کردن نام الزامی است");
        }
    }

    public class RankAddHandler : ICommandHandler<RankAddCommand, bool>
    {
        private readonly IRankRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RankAddHandler(IRankRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(RankAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = new Rank(request.Name, request.Description);

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
