using Webgostar.Framework.Base.BaseModels;

namespace Application.UseCases.OrganizationCases.ConfigOrganizationCase
{
    public class ConfigOrganizationEditCommand : ICommand<bool>
    {
    }

    public class ConfigOrganizationEditValidator : ICommand<bool>
    {
        public ConfigOrganizationEditValidator()
        {

        }
    }

    public class ConfigOrganizationEditHandler : ICommandHandler<ConfigOrganizationEditCommand, bool>
    {
        public async Task<OperationResult<bool>> Handle(ConfigOrganizationEditCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
