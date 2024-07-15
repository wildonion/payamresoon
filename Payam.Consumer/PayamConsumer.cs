using System.Numerics;
using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using MassTransit;
using Newtonsoft.Json;
using PayamEvents;

public interface IEvent
{
    DateTime Timestamp { get; }
    string CorrelationId { get; }
}

public class PayamConsumer : IConsumer<PayamMessage>
{

    public async Task Consume(ConsumeContext<PayamMessage> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received OTP message: {message.Message} for phone numbers: {string.Join(", ", message.PhoneNumbers)}");

        // var password = System.Environment.GetEnvironmentVariable("PASSWORD");
        // var line = System.Environment.GetEnvironmentVariable("LINE");

        var password = "";
        var line = "";

        long l = 0;
        long.TryParse(line, out l);

        var response = await PayamSender.SendSms(password,
            l,
            context.Message.PhoneNumbers,
            context.Message.Message
        );

        await Task.CompletedTask;

    }
}

