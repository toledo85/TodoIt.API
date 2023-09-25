using System.ComponentModel.DataAnnotations;

namespace TodoIt.Application.Dtos.Todos;

public class UpdateTodoDto {
    [Required] public int Id { get; set; }
    [Required] public string Title { get; set; } = string.Empty;
    [Required] public string Content { get; set; } = string.Empty;
    [Required] public bool IsDone { get; set; }
}