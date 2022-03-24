using Microsoft.EntityFrameworkCore;
using SystemProject.Models.UserAccount;

namespace SystemProject.DataApp
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UserAccount> Users { get; set; }
    }
}
