using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace KEDI.Core.Premise.DependencyInjection
{
    public interface IScopeFactory<TService> where TService : class
    {
        TService GetService();
        TService GetRequiredService();
        IEnumerable<TService> GetServices();
    }

    public class ScopeFactory<TService> : IScopeFactory<TService> where TService : class
    {
        private readonly IServiceScope _scope;
        public ScopeFactory(IServiceScopeFactory scopeFactory)
        {
            _scope = scopeFactory.CreateScope();
        }

        public TService GetRequiredService()
        {
            return _scope.ServiceProvider.GetRequiredService<TService>();
        }

        public TService GetService()
        {
            return _scope.ServiceProvider.GetService<TService>();
        }

        public IEnumerable<TService> GetServices()
        {
            return _scope.ServiceProvider.GetServices<TService>();
        }
    }
}
