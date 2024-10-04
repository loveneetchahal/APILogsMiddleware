using APILogs.Models;
using Microsoft.EntityFrameworkCore;

namespace APILogs.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        } 
        public DbSet<RequestLogs> RequestLogs { get; set; }
    }
}
