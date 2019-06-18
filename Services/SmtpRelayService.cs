using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SmtpRelay.Services
{
    internal class SmtpRelayService : BackgroundService
    {
        public SmtpRelayService(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<SmtpRelayService>();
        }

        
        public ILogger Logger { get; }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("SmtpRelayService is starting.");
            
            stoppingToken.Register(() => Logger.LogInformation("SmtpRelayService is stopping."));
            
            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("SmtpRelayService is doing background work.");
                
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
            
            Logger.LogInformation("SmtpRelayService has stopped.");
        }
    }
}
