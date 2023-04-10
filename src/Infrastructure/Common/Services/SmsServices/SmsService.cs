using Infrastructure.Common.Interfaces;
using RestSharp;
using RestSharp.Service;
using RestSharp.Service.Models;
using System.Net;

namespace Infrastructure.Common.Services.SmsServices;

public class SmsService : ISmsService
{
    #region Initialize
    private readonly string baseUrl = "";

    private readonly IRestService restService;

    public SmsService(IRestService _restService)
    {
        restService = _restService;
    }
    #endregion

    public async Task<SmsResult> SendAsync(string reciever, string text)
    {
        // Write your custom.
        #region sample
        var parameters = new Dictionary<string, string> {
            {"receptor", reciever },
            { "message", text }
        };
        var result = await restService.RequestAsync(baseUrl + "sms/send.json", Method.GET, new RestConfig
        {
            Parameters = parameters
        });
        if (result.StatusCode == HttpStatusCode.OK)
            return SmsResult.Success;
        return SmsResult.Failed();
        #endregion
    }

    public async Task<SmsResult> SendOtpAsync(string reciever, string token)
    {
        // Write your custom.
        #region sample
        var result = await restService.RequestAsync(baseUrl + "verify/lookup.json", Method.GET);
        if (result.StatusCode == HttpStatusCode.OK)
            return SmsResult.Success;
        return SmsResult.Failed();
        #endregion
    }
}