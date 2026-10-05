using Domain.Enum;

namespace Application.Dto
{
    namespace Application.DTOs
    {
        public class TaskDto
        {
        public Guid Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string? Description { get; set; }
            public DateTime? DueDate { get; set; }
            public TaskManagerStatus Status { get; set; } = TaskManagerStatus.Pendente;
        }
    }

}
