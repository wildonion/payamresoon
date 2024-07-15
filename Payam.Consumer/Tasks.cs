


// 'async void' can also be used for specific use cases, such as events:
// public async void SendVerifyButton_Click(object sender, EventArgs e)  
using System.Numerics;
using System.Text;
using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class PayamSender
{
    public static async Task<string> SendSms(
        string password, long line, string[] phones, string text)
    {
        
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", password);

        var payload = new
        {
            lineNumber = line,
            messageText = text,
            mobiles = phones,
            sendDateTime = (DateTime?)null // or you can use null directly
        };

        var jsonPayload = JsonConvert.SerializeObject(payload);
        HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        
        var response = await httpClient.PostAsync("https://api.sms.ir/v1/send/bulk", content);
        var result = await response.Content.ReadAsStringAsync();

        // Handle the response if needed
        Console.WriteLine(result);

        return result;

    }
}