using System;
using MassTransit;


namespace PayamEvents
{

    public interface IEvent
    {
        DateTime Timestamp { get; }
        string CorrelationId { get; }
    }

    public class PayamMessage : IEvent
    {
        public required string Message { get; set; }
        public required string[] PhoneNumbers { get; set; }
        public DateTime Timestamp { get; set; }
        public string CorrelationId { get; set; }

    }
}