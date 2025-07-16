namespace Contracts.IContractService;

public interface ISmsService
{
    Task<dynamic?>? Init();
    Task<dynamic?> Send(string to, string message);
    Task<dynamic?> SendVerificationCode(string to, string smsBody);
}