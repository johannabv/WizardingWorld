using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WizardingWorld.Data;
using WizardingWorld.Infra;

namespace Tests {
    public class TestHost<TProgram> : WebApplicationFactory<TProgram> where TProgram : class {
        protected override void ConfigureWebHost(IWebHostBuilder b) {
            base.ConfigureWebHost(b);
            b.ConfigureTestServices(s => {
                RemoveDb<ApplicationDbContext>(s);
                RemoveDb<WizardingWorldDb>(s);
                s.AddEntityFrameworkInMemoryDatabase();
                AddDb<ApplicationDbContext>(s);
                AddDb<WizardingWorldDb>(s);
                EnsureCreated(s, typeof(ApplicationDbContext), typeof(WizardingWorldDb));
            });
        }
        private static void EnsureCreated(IServiceCollection s, params Type[] types) {
            ServiceProvider? sp = s.BuildServiceProvider();
            using IServiceScope scope = sp.CreateScope();
            IServiceProvider scopedServices = scope.ServiceProvider;
            foreach (Type type in types) EnsureCreated(scopedServices, type);
        }
        private static void EnsureCreated(IServiceProvider s, Type t) {
            if (s?.GetRequiredService(t) is not DbContext c)
                throw new ApplicationException($"DBContext {t} not found");
            c?.Database?.EnsureCreated();
            if (!(c?.Database?.IsInMemory() ?? false))
                throw new ApplicationException($"DBContext {t} is not in memory");
        }
        private static void AddDb<T>(IServiceCollection s) where T : DbContext
            => s?.AddDbContext<T>(o => { o.UseInMemoryDatabase("Tests"); });
        private static void RemoveDb<T>(IServiceCollection s) where T : DbContext {
            ServiceDescriptor? descriptor = s?.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<T>));
            if (descriptor is not null) { s?.Remove(descriptor); }
        }
    }
}