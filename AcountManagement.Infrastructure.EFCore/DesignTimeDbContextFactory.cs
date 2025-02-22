using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore
{
    public class AccountContextFactory : IDesignTimeDbContextFactory<AccountContext>
    {
        public AccountContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();

            // Use your actual connection string here
            optionsBuilder.UseSqlServer("Server=.;Database=AfzarAzmaNew;Integrated Security=True;");

            return new AccountContext(optionsBuilder.Options);
        }
    }
}
