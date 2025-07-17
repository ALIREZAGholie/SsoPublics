using Application.IRepositories.ICompanyRepositories;
using Domain.CompanyAgg.CompanyEntity;
using FluentValidation;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.UseCases.AuthCases.CompanyCase.Add
{
    public class CompanyAddCommand : ICommand<bool>
    {
        public long ParentId { get; set; }
        public long LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class CompanyAddValidator : AbstractValidator<CompanyAddCommand>
    {
        public CompanyAddValidator()
        {
            RuleFor(r => r.LocationId)
                .NotEmpty().WithMessage("محل را وارد کنید");
            RuleFor(r => r.ParentId)
                .NotEmpty().WithMessage("مجموعه بالاسری را وارد کنید");
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("نام را وارد کنید");
            RuleFor(r => r.Address)
                .NotEmpty().WithMessage("آدرس را وارد کنید");
            RuleFor(r => r.Phone)
                .Length(11).WithMessage("طول شماره تماس صحیح نیست")
                .NotEmpty().WithMessage("شماره تلفن را وارد کنید");
        }
    }

    public class CompanyAddHandler : ICommandHandler<CompanyAddCommand, bool>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyAddHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(CompanyAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                Company company = new(request.ParentId, request.Name, request.Address, request.Phone, request.LocationId);

                await _companyRepository.Add(company, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var parents = await _companyRepository.GetParents(request.ParentId, company.Id);
                company.SetParents(parents);
                await _companyRepository.Update(company);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

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
