using JurChat.Server.Services.Contracts;

namespace JurChat.Server.Services.Abstractions
{
    public interface IChatTaskService
    {
        Task<ICollection<ChatTaskDto>> GetChatTask();

        Task<ChatTaskDto> GetById(int id);

        Task<int> Create(ChatTaskDto advertisementDto);

        Task Update(int id, ChatTaskDto advertisementDto);

        Task Delete(int id);
    }
}
