using SogetiTodoApp.Models.Domain;

namespace SogetiTodoApp.Models
{
    // View model for the list of items
    public class VmList
    {
        public List<TodoItem> TodoItemsDone { get; set; }
        public List<TodoItem> TodoItemsNotDone { get; set; }
    }
}
