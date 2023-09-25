using Services.Contracts;

namespace Services.Abstractions
{
    public interface IProjectService
    {
        Task<ICollection<ProjectDto>> GetProjects();

        Task<ProjectDto> GetById(int id);

        Task<int> Create(ProjectDto advertisementDto);

        Task Update(int id, ProjectDto advertisementDto);

        Task Delete(int id);
    }
}
