using JurChat.Server.Services.Contracts;

namespace JurChat.Server.Services.Abstractions
{
    public interface IMessageFileService
    {
        Task<ICollection<MessageFileDto>> GetMessageFiles();

        Task<MessageFileDto> GetById(int id);

        Task<int> Create(MessageFileDto advertisementDto);

        Task Update(int id, MessageFileDto advertisementDto);

        Task Delete(int id);
    }
}
