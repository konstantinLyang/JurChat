using AutoMapper;
using Infrastructure.Repositories.Implementations;
using Web.App.Models;

namespace Web.App
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
