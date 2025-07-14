using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebtel.DeveloperTest.SL
{
    public class DbContextFactory : IDbContextFactory
    {
        public void CreateDbCOntest()
        {
            throw new NotImplementedException();
        }

        public void CreateContext(IServiceCollection servics)
        {
            servics.AddSingleton<ILibraryContext, LibraryContext>();
        }
    }
}
