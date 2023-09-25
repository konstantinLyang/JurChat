using AutoMapper;
using JurChat.Server.Infrastructure.Repositories.Implementations;
using JurChat.Web.Models;

namespace JurChat.Web
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ChatRepository, ChatModel>().ReverseMap();
            CreateMap<ChatTaskRepository, ChatTaskModel>().ReverseMap();
            CreateMap<MessageFileRepository, MessageFileModel>().ReverseMap();
            CreateMap<MessageRepository, MessageModel>().ReverseMap();
            CreateMap<ProjectRepository, ProjectModel>().ReverseMap();
            CreateMap<UserRepository, UserModel>().ReverseMap();
        }
    }
}
