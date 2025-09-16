namespace ServerManagement.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
    public DateTime CompletedDate { get; set; }
    public bool FreshAdd { get; set; }
};