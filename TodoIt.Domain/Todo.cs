namespace TodoIt.Domain;

public class Todo {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public bool IsDone { get; set; }
    public User? User { get; set; }
}