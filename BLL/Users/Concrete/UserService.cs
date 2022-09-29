using AutoMapper;
using BLL.Users.Abstract;
using DAL.Abstract;
using DomainEntities.Users;
using DTO.Users;

namespace BLL.Users.Concrete
{
    public class UserService : IUserService
    {
        #region fields

        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;

        #endregion

        #region constructors
        
        /// <summary>
        /// Initialzies the new insatnce of <see cref="UserService"/> class/
        /// </summary>
        /// <param name="userRepository">user repository.</param>
        /// <param name="mapper">Autommaper instance.</param>
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #endregion

        #region operations

        public async Task<IEnumerable<UserDTO>> Get()
        {
            IEnumerable<User> usersEntity = await _userRepository.Get();

            if (usersEntity == null || !usersEntity.Any())
            {
                return null;
            }

            IEnumerable<UserDTO> usersDto = _mapper.Map<IEnumerable<UserDTO>>(usersEntity);

            return usersDto;
        }

        public async Task<UserDTO> Get(int id)
        {
            User userEntity = await _userRepository.Get(id);

            if (userEntity is null)
            {
                return null;
            }

            return _mapper.Map<User,UserDTO>(userEntity);
        }

        #endregion
    }
}