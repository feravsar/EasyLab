using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EasyLab.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using System;

namespace EasyLab.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        #region Constructors

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion


        #region Dbsets - Alphabetic order

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUserMap { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Core.Entities.Project> Projects { get; set; }

        #endregion

        #region Configuring database models -  Aplhabetic order


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>(ConfigureAssignment);
            modelBuilder.Entity<Course>(ConfigureCourse);
            modelBuilder.Entity<CourseUser>(ConfigureCourseUser);
            modelBuilder.Entity<Language>(ConfigureLanguage);
            modelBuilder.Entity<RefreshToken>(ConfigureRefreshToken);
            modelBuilder.Entity<Core.Entities.Project>(this.ConfigureProject);
            modelBuilder.Entity<User>(ConfigureUser);
        }

        public void ConfigureAssignment(EntityTypeBuilder<Assignment> entity)
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Id).ValueGeneratedOnAdd();

            entity.HasOne(t => t.Author)
                .WithMany(t => t.Assignments)
                .HasForeignKey(t => t.AuthorId)
                .HasConstraintName("FK_User_Assignment");

            entity.HasOne(t => t.Course)
                .WithMany(t => t.Assignments)
                .HasForeignKey(t => t.CourseId)
                .HasConstraintName("FK_Course_Assignment")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Language)
                .WithMany(t => t.Assignments)
                .HasForeignKey(t => t.LanguageId)
                .HasConstraintName("FK_Language_Assignment");
        }

        public void ConfigureCourse(EntityTypeBuilder<Course> entity)
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Id).ValueGeneratedOnAdd();
        }

        public void ConfigureCourseUser(EntityTypeBuilder<CourseUser> entity)
        {
            entity.HasKey(t => new { t.UserId, t.CourseId, t.IsInstructor });

            entity.HasOne(t => t.User)
                .WithMany(t => t.Courses)
                .HasForeignKey(t => t.UserId)
                .HasConstraintName("FK_User_CourseUsers")
                .OnDelete(DeleteBehavior.Restrict);;

            entity.HasOne(t => t.Course)
                .WithMany(t => t.Users)
                .HasForeignKey(t => t.CourseId)
                .HasConstraintName("FK_Course_CourseUsers")
                .OnDelete(DeleteBehavior.Restrict);;
        }

        public void ConfigureLanguage(EntityTypeBuilder<Language> entity)
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Id).ValueGeneratedOnAdd();
        }

        public void ConfigureRefreshToken(EntityTypeBuilder<RefreshToken> entity)
        {
            entity.HasOne(d => d.User)
                .WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_RefreshToken");
        }

        public void ConfigureProject(EntityTypeBuilder<Core.Entities.Project> entity)
        {

            entity.HasKey(t => t.ProjectId);

            entity.HasIndex(t => new { t.UserId, t.AssignmentId })
            .IsUnique();

            entity.HasOne(t => t.Assignment)
                .WithMany(t => t.Projects)
                .HasForeignKey(t => t.AssignmentId)
                .HasConstraintName("FK_Assignment_StudentAssignments")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.User)
                .WithMany(t => t.Projects)
                .HasForeignKey(t => t.UserId)
                .HasConstraintName("FK_Assignment_UserAssignments")
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void ConfigureUser(EntityTypeBuilder<User> entity)
        {
            entity.Property(t => t.Id).ValueGeneratedOnAdd();

            entity.HasIndex(t => t.Email)
                .IsUnique();

            entity.HasIndex(t => t.PhoneNumber)
                .IsUnique();
        }


        #endregion

    }
}
