using Microsoft.EntityFrameworkCore;
using SystemProject.Models.Branch;
using SystemProject.Models.Company;
using SystemProject.Models.UserAccount;

namespace SystemProject.DataApp
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UserAccount> OUSR { get; set; }
        public DbSet<Currency> OCURE { get; set; }
        public DbSet<Company> COMP { get; set; }
        public DbSet<Branch> BRAN { get; set; }
        public DbSet<BranchInfo> BRINFO { get; set; }
        public DbSet<ExchangeRate> EXRATE { get; set; }                                                             
    }
}
