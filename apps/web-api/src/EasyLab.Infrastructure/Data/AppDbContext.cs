using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EasyLab.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyLab.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {

        #region Constructors

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region Dbsets - Alphabetic order

     
        #endregion

        #region Configuring database models -  Aplhabetic order


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(ConfigureUser);
        }


        public void ConfigureUser(EntityTypeBuilder<User> entity)
        {

            entity.HasIndex(t => t.PhoneNumber)
                .IsUnique();
        }


        #endregion

    }
}
