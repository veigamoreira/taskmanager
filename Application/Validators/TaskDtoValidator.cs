using Application.Dto.Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("O título é obrigatório")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres");

            RuleFor(t => t.Description)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres")
                .When(t => !string.IsNullOrEmpty(t.Description));

            RuleFor(t => t.DueDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("A data de vencimento deve ser futura")
                .When(t => t.DueDate.HasValue);

            RuleFor(t => t.Status)
                .IsInEnum().WithMessage("Status inválido. Use: Pendente, EmProgresso ou Concluida");
        }
    }
}
