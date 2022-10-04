using Microsoft.EntityFrameworkCore;
using SogetiTodoApp.Models.Domain;

namespace SogetiTodoApp.Data
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions options) : base(options) {}

        // Set the table added to the database
        public DbSet<TodoItem> Todos { get; set; }
    }
}
