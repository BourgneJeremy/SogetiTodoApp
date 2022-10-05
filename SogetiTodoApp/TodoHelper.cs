using SogetiTodoApp.Models.Domain;

namespace SogetiTodoApp
{
    public static class TodoHelper
    {
        /// <summary>
        /// Generate todos
        /// </summary>
        public static List<TodoItem> GenerateTodos()
        {
            return new List<TodoItem>()
            {
                new TodoItem() { Title = "Aller faire les courses", Description = "Lait, oignons, crème fraiche", IsDone = false },
                new TodoItem() { Title = "Faire le ménage", Description = "Aspirateur, machine à laver, sol, serpière", IsDone = false },
                new TodoItem() { Title = "Faire du Hip Hop", Description = "Travailler les isolations", IsDone = true }
            };
        }

        /// <summary>
        /// Add a new todo without the Id automatically generated
        /// </summary>
        public static TodoItem AddTodoItem(string title, string description, bool isDone)
        {
            return new TodoItem()
            {
                Title = title,
                Description = description,
                IsDone = isDone
            };
        }
    }
}
