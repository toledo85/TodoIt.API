using System.ComponentModel.DataAnnotations;

namespace TodoIt.Application.Dtos.Todos;

public class CreateTodoDto {
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;
}