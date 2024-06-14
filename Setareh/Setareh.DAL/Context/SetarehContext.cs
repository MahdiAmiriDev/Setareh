
using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Entities.ContacUs;
using Setareh.DAL.Entities.User;

namespace Setareh.DAL.Context
{
    public class SetarehContext:DbContext
    {
        #region Constractor

        public SetarehContext(DbContextOptions<SetarehContext> options):base(options)
        {
            
        }

        #endregion


        #region DbSets

        public DbSet<User> User { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

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
                    Password = "2c216b1ba5e33a27eb6d3df7de7f8c36"
                });

			base.OnModelCreating(modelBuilder);
		}

	}
}
