
using Microsoft.EntityFrameworkCore;
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

        #endregion
    }
}
