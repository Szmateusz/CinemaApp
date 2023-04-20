using CinemaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp
{  
        public class DBContext : IdentityDbContext<UserModel>
        {
            public DBContext(DbContextOptions<DBContext> options) : base(options) { }


          
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

            }

        }
    
}
