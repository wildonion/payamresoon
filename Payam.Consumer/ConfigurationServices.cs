using System.Text.RegularExpressions;
using MassTransit;
using MassTransit.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



public static class MassTransitConfig
{
    public static void ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ReceiveEndpoint("payam_message_queue", e =>
                               {
                                   e.ConfigureConsumer<PayamConsumer>(ctx);
                               });
            });

            x.AddConsumer<PayamConsumer>(); // Register your consumer class
        });

    }
}