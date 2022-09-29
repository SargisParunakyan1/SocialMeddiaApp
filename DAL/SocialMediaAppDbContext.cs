using DomainEntities.Users;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SocialMediaAppDbContext : DbContext
    {
        #region properties

        public DbSet<User> Users { get; set; }

        #endregion

        #region constructors

        public SocialMediaAppDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion
    }
}