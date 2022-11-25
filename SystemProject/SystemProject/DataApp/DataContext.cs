using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using SystemProject.Models.Branch;
using SystemProject.Models.BusinessPartner;
using SystemProject.Models.Company;
using SystemProject.Models.Other;
using SystemProject.Models.UserAccount;
using SystemProject.Models.UsersPrivilege;

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
        public DbSet<Roles> ROLES { get; set; } 
        public DbSet<RolesPrivilege> ROLEPRIVI { get; set; }
        public DbSet<Function> FUNCTI { get; set; }
        public DbSet<UsersPrivilege> USERPRIVI { get; set; }
        public DbSet<PrimaryKey> PRIMARYKEYS { get; set; }
        public DbSet<Customer> CUSMER { get; set; }
        public DbSet<Vendor> VENDOR { get; set; }
    }
}
