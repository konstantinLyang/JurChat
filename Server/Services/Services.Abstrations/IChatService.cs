using Services.Contracts;

namespace Services.Abstractions
{
    public interface IChatService
    {
        Task<ICollection<ChatDto>> GetChats();

        Task<ChatDto> GetById(int id);

        Task<int> Create(ChatDto advertisementDto);

        Task Update(int id, ChatDto advertisementDto);

        Task Delete(int id);
    }
}
