using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Получить список
        /// </summary>
        public async Task<ICollection<UserDto>> GetUsers() => 
            _mapper.Map<ICollection<User>, ICollection<UserDto>>(await _userRepository.GetAllUsersAsync());

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО пользователя</returns>
        public async Task<UserDto> GetById(int id) =>
            _mapper.Map<UserDto>(await _userRepository.GetAsync(id));

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="courseDto">ДТО пользователя</param>
        /// <returns>идентификатор</returns>
        public async Task<int> Create(UserDto userDto)
        {
            var user = await _userRepository.AddAsync(_mapper.Map<UserDto, User>(userDto));
            await _userRepository.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="courseDto">ДТО пользователя</param>
        public async Task Update(int id, UserDto userDto)
        {
            var entity = _mapper.Map<UserDto, User>(userDto);
            entity.Id = id;
            _userRepository.Update(entity);
            await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task Delete(int id)
        {
            var entity = await _userRepository.GetAsync(id);
            entity.Deleted = true;
            await _userRepository.SaveChangesAsync();
        }
    }
}