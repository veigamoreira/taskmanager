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

           RuleFor(t => t.Status)
                .IsInEnum().WithMessage("Status inválido. Use: Pendente, Em Progresso ou Concluida");
        }
    }
}
