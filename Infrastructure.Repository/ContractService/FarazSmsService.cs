using Contracts.IContractService;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.ContractService;

public class FarazSmsService(ILoggerFactory logger) : ISmsService
{
    private HttpClient _client;
    private const string BASE_ADDRESS = "https://api2.ippanel.com/api/v1";
    private const string API_KEY = "P1M6EZ1jxso643CGAvwe_v_96Zl3CLQumqIXJso7fec=";
    private const string PATTERN_CODE = "9mnm9wh9shirq52";
    private const string FROM = "3000505";

    public Task<dynamic?>? Init()
    {
        _client = new HttpClient();

        return null;
    }

    public async Task<dynamic?> Send(string to, string message)
    {
        Init();
        var request = new HttpRequestMessage(HttpMethod.Post, $"{BASE_ADDRESS}/sms/send/webservice/single");
        request.Headers.Add("apikey", API_KEY);
        var content =
            new StringContent(
                "{\"recipient\": [\"" + to + "\"],\"sender\": \"" + FROM + "\",\"recipient\": \"" + to +
                "\",\"message\":" + message + "}", null, "application/json");
        request.Content = content;
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
    }

    public async Task<dynamic?> SendVerificationCode(string to, string smsBody)
    {
        Init();
        var request = new HttpRequestMessage(HttpMethod.Post, $"{BASE_ADDRESS}/sms/pattern/normal/send");
        request.Headers.Add("apikey", API_KEY);
        var content =
            new StringContent(
                "{\"code\": \"" + PATTERN_CODE + "\",\"sender\": \"" + FROM + "\",\"recipient\": \"" + to +
                "\",\"variable\": {\"verification-code\":" +
                int.Parse(smsBody) + "}}", null, "application/json");
        request.Content = content;
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
    }
}