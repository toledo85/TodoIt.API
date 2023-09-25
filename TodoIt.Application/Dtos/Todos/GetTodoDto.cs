namespace TodoIt.Application.Dtos.Todos;

public class GetTodoDto {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}