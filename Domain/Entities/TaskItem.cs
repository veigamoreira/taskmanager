using Domain.Enum;

namespace Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskManagerStatus Status { get; set; } = TaskManagerStatus.Pendente;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
