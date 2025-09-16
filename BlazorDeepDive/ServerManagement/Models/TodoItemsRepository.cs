namespace ServerManagement.Models;

public static class TodoItemsRepository
{
    private static List<TodoItem> Items { get; } =
    [
        new()
        {
            Id = 1,
            Text = "Task 1"
        },
        new()
        {
            Id = 2,
            Text = "Task 2"
        },
    ];

    public static IEnumerable<TodoItem> GetItems() => Items
        .OrderBy(x => x.IsComplete)
        .ThenByDescending(x => x.Id);

    public static void Add(TodoItem item)
    {
        item.Id = Items.Count + 1;
        Items.Add(item);
    }

    public static void Update(TodoItem item)
    {
        var toUpdateItem = Items.FirstOrDefault(x => x.Id == item.Id);

        if (toUpdateItem is null)
        {
            return;
        }

        toUpdateItem.IsComplete = toUpdateItem.IsComplete;
        toUpdateItem.CompletedDate = item.CompletedDate;
        toUpdateItem.Text = item.Text;
    }

    public static void Delete(TodoItem item)
    {
        Items.Remove(item);
    }
}