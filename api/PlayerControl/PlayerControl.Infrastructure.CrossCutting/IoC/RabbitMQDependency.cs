using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PlayerControl.Application.Interfaces;
using PlayerControl.Infrastructure.Messaging.Producer;
using PlayerControl.Infrastructure.Messaging;
using RabbitMQ.Client;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class RabbitMQDependency
    {
        public static IServiceCollection AddRabbitMQDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettings>(sp =>
            {
                configuration.GetSection(RabbitMQSettings.AppSettings);
            });

            services.AddSingleton(sp =>
            {
                RabbitMQSettings config = sp.GetRequiredService<IOptions<RabbitMQSettings>>().Value;
                var factory = new ConnectionFactory
                {
                    HostName = config.Hostname,
                    UserName = config.Username,
                    Password = config.Password
                };
                return factory.CreateConnection();
            });

            services.AddSingleton<ChannelManager>();

            services.AddScoped<IMessageProducer>(sp =>
            {
                var channelManager = sp.GetRequiredService<ChannelManager>();
                var config = sp.GetRequiredService<IOptions<RabbitMQSettings>>();
                return new RabbitMQProducer(channelManager.GetChannel(), config);
            });

            return services;
        }
    }
}
