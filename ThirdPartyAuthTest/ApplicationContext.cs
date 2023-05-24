using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThirdPartyAuthTest.Models;

namespace ThirdPartyAuthTest
{    
    public class ApplicationContext : IdentityDbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=LAPTOP-8EV8ASUL\\SQLEXPRESS;Database=GoogleAuth;Trusted_Connection=True;");
        //}

        //public DbSet<ErrorViewModel> ErrorViewModel { get; set; }
        //public DbSet<LoginViewModel> LoginViewModel { get; set; }
        //public DbSet<RegisterViewModel> RegisterViewModel { get; set; }

    }
}
