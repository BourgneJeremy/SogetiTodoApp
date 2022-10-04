using SogetiTodoApp.Models.Domain;

namespace SogetiTodoApp.Models
{
    // View model for the list of items
    public class VmListAndCreate
    {
        public List<TodoItem> TodoItemsDone { get; set; }
        public List<TodoItem> TodoItemsNotDone { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
