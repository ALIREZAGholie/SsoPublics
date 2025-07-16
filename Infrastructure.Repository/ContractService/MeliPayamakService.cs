using Contracts.IContractService;
using Melipayamak;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.ContractService;

public class MeliPayamakService(ILoggerFactory logger) : ISmsService
{
    private RestClient _restClient;
    private const string USERNAME = "09366707983";
    private const string PASSWORD = "Mmamini@1955756356";
    private const string FROM = "50002710007983";

    public Task<dynamic?>? Init()
    {
        _restClient = new RestClient(USERNAME, PASSWORD);
        return null;
    }

    public Task<dynamic?> Send(string to, string message)
    {
        Init();
        var result = _restClient.Send(to, FROM, message, false);

        if (result?.RetStatus == 1) return Task.FromResult<dynamic?>(true);
        return Task.FromResult<dynamic?>(false);
    }

    public Task<dynamic?> SendVerificationCode(string to, string smsBody)
    {
        Init();
        var result = _restClient.Send(to, FROM, smsBody, false);

        return result?.RetStatus == 1 ? Task.FromResult<dynamic?>(true) : Task.FromResult<dynamic?>(false);
    }
}