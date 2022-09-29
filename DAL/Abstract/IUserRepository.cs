using DomainEntities.Users;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        #region operations

        Task<IEnumerable<User>> Get();

        Task<User> Get(int id);

        #endregion
    }
}
