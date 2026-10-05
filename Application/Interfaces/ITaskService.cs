using Application.Dto.Application.DTOs;


namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto?> GetByIdAsync(Guid id);
        Task<TaskDto> CreateAsync(TaskDto dto);
        Task<TaskDto?> UpdateAsync(Guid id, TaskDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

