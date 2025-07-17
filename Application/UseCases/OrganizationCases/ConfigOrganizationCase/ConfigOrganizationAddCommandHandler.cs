using FluentValidation;
using Webgostar.Framework.Base.BaseModels;

namespace Application.UseCases.OrganizationCases.ConfigOrganizationCase
{
    public class ConfigOrganizationAddCommand : ICommand<bool>
    {
    }

    public class ConfigOrganizationAddValidator : AbstractValidator<ConfigOrganizationAddCommand>
    {
        public ConfigOrganizationAddValidator()
        {

        }
    }

    public class ConfigOrganizationAddHandler : ICommandHandler<ConfigOrganizationAddCommand, bool>
    {
        public async Task<OperationResult<bool>> Handle(ConfigOrganizationAddCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
