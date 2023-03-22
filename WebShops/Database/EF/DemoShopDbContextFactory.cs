using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.EF
{
    public class DemoShopDbContextFactory : IDesignTimeDbContextFactory<DemoDbcontext>
    {
        public DemoDbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSetting.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DemoShopData");

            var optionsBuilder = new DbContextOptionsBuilder<DemoDbcontext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DemoDbcontext(optionsBuilder.Options);
        }
    }
}
