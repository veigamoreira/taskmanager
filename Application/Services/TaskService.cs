using Application.Dto.Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto?> GetByIdAsync(Guid id)
        {
            var task = await _repository.GetByIdAsync(id);
            return _mapper.Map<TaskDto?>(task);
        }

        public async Task<TaskDto> CreateAsync(TaskDto dto)
        {
            var entity = _mapper.Map<TaskItem>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TaskDto>(entity);
        }

        public async Task<TaskDto?> UpdateAsync(Guid id, TaskDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return _mapper.Map<TaskDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
