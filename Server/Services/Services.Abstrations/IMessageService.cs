using Services.Contracts;

namespace Services.Abstractions
{
    public interface IMessageService
    {
        Task<ICollection<MessageDto>> GetMessages();

        Task<MessageDto> GetById(int id);

        Task<int> Create(MessageDto advertisementDto);

        Task Update(int id, MessageDto advertisementDto);

        Task Delete(int id);
    }
}
