using Services.Contracts;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetUsers();

        Task<UserDto> GetById(int id);

        Task<int> Create(UserDto advertisementDto);

        Task Update(int id, UserDto advertisementDto);

        Task Delete(int id);
    }
}
