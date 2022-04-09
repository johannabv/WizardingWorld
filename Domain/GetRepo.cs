﻿using Microsoft.Extensions.DependencyInjection;

namespace WizardingWorld.Domain {
    public static class GetRepo {
        private static IServiceProvider? service;

        public static TRepo? Instance<TRepo>() where TRepo : class 
            => service?.CreateScope()?.ServiceProvider.GetRequiredService<TRepo>();
        public static void SetService(IServiceProvider s) => service = s;
    }
}
