using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Reflection.PortableExecutable;
using SystemProject.Repository.ServicesClass;

namespace KEDI.Core.Premise
{
    public class ContextTracker: BackgroundService
    {

        private readonly ILogger<ContextTracker> _logger;
        private readonly ServicesGeneratePrimaryKey _servicesGeneratePrimaryKey;
        public int Interval { get; set; } = 1000 * 10; // Check every 1 hours
        private static readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        public ContextTracker(ILogger<ContextTracker> logger, ServicesGeneratePrimaryKey servicesGeneratePrimaryKey)
        {
            _logger = logger;
            _servicesGeneratePrimaryKey = servicesGeneratePrimaryKey;    
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Factory.StartNew(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(Interval, stoppingToken);
                    await Task.Factory.StartNew(async () =>
                    {
                         await _servicesGeneratePrimaryKey.Test();                          
                    });                        
                    
                }
            });
        }
    }
}
