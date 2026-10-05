using Application.Dto.Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Retorna todas as tarefas cadastradas.
        /// </summary>
        /// <returns>Lista de tarefas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Retorna uma tarefa específica pelo ID.
        /// </summary>
        /// <param name="id">Identificador único da tarefa</param>
        /// <returns>Tarefa encontrada ou 404 se não existir</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskDto>> GetById(Guid id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        /// <param name="dto">Objeto com os dados da tarefa</param>
        /// <returns>Tarefa criada</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaskDto>> Create(TaskDto dto)
        {
            var created = await _taskService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma tarefa existente.
        /// </summary>
        /// <param name="id">Identificador único da tarefa</param>
        /// <param name="dto">Objeto com os dados atualizados</param>
        /// <returns>Tarefa atualizada ou 404 se não existir</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaskDto>> Update(Guid id, TaskDto dto)
        {
            var updated = await _taskService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// Remove uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">Identificador único da tarefa</param>
        /// <returns>204 se removida, 404 se não encontrada</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _taskService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
