using DTO.Users;

namespace BLL.Users.Abstract
{
    public interface IUserService
    {
        #region operations

        Task<IEnumerable<UserDTO>> Get();

        Task<UserDTO> Get(int id);

        #endregion
    }
}
