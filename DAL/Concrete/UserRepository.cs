using DAL.Abstract;
using DomainEntities.Users;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        #region fields

        private readonly SocialMediaAppDbContext _context;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes the new instance of <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">DB context.</param>
        public UserRepository(SocialMediaAppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region operations

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        #endregion
    }
}
