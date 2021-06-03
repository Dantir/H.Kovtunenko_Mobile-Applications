using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Camera_App.Web.Models;

namespace Camera_App.Web.Context
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected AzureDbContext()
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
