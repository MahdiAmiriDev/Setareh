
using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Entities.User;

namespace Setareh.DAL.Context
{
    public class Context:DbContext
    {
        #region Constractor

        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }

        #endregion


        #region DbSets

        public DbSet<User> User { get; set; }

        #endregion
    }
}
