using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Rebtel.DeveloperTest.SL
{
    public class DbContextFactory 
    {
        public void RegisterDBContext(IServiceCollection servics)
        {
            servics.AddSingleton<ILibraryContext, LibraryContext>();
        }
    }
}
