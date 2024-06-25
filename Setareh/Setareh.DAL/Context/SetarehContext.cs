
using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Entities.AboutMe;
using Setareh.DAL.Entities.Acitivity;
using Setareh.DAL.Entities.ContacUs;
using Setareh.DAL.Entities.Education;
using Setareh.DAL.Entities.Expreince;
using Setareh.DAL.Entities.User;

namespace Setareh.DAL.Context
{
    public class SetarehContext : DbContext
    {
        #region Constractor

        public SetarehContext(DbContextOptions<SetarehContext> options) : base(options)
        {

        }

        #endregion


        #region DbSets

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }


        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    CreateDate = DateTime.Now,
                    Email = "mahdiamiridev@gmail.com",
                    FirstName = "مهدی",
                    LastName = "امیری",
                    Id = 1,
                    IsActive = true,
                    Mobile = "09337132998",
                    Password = "2C-21-6B-1B-A5-E3-3A-27-EB-6D-3D-F7-DE-7F-8C-36"
                });

            modelBuilder.Entity<ContactUs>()
                .HasData(new ContactUs
                {
                    Answer = "ندارد",
                    CreateDate = DateTime.Now,
                    Description = "سلام عالی",
                    Email = "mahdiamiridev@gmail.com",
                    FirstName = "مهدی",
                    Id = 1,
                    LastName = "امیری",
                    Mobile = "09337132998",
                    Title = "تست"
                });

            modelBuilder.Entity<AboutMe>()
    .HasData(new AboutMe
    {
        Description = "",
        birthDate = DateOnly.FromDateTime(DateTime.Now),
        CreateDate = DateTime.Now,
        FirstName = "",
        Email = "",
        LastName = "",
        Id = 1,
        Location = "",
        Mobile = "",
        Position = "",
        ImageName = ""
    });

            base.OnModelCreating(modelBuilder);
        }

    }
}
