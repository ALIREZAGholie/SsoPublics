using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Context.Contexts
{
    public class EfContextInitializer(EfContext context, ILoggerFactory logger)
    {
        private readonly ILogger _logger = logger.CreateLogger<EfContextInitializer>();

        public async Task InitializeAsync()
        {
            try
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError("Migration error {exception}", exception);
            }
        }
    }
}