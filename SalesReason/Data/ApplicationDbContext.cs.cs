using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SalesReason> SalesReasons { get; set; }
    }
}