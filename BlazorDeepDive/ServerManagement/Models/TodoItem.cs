namespace ServerManagement.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;

    private bool _isComplete;
    public bool IsComplete
    {
        get => _isComplete;
        set
        {
            if (value)
            {
                CompletedDate = DateTime.Now;
            }
            else
            {
                CompletedDate = null;
            }

            _isComplete = value;
        }
    }

    public DateTime? CompletedDate { get; set; }
    public bool FreshAdd { get; set; }
};