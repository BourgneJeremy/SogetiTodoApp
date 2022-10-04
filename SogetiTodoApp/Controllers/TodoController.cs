using Microsoft.AspNetCore.Mvc;
using SogetiTodoApp.Data;
using SogetiTodoApp.Models;
using SogetiTodoApp.Models.Domain;

namespace SogetiTodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext todoContext;

        /// <summary>
        /// Initialize the database context 
        /// </summary>
        /// <param name="todoContext">The context containing "TodoContext" and Todo Item Db Set</param>
        public TodoController(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }

        /// <summary>
        /// Generated data for tests
        /// </summary>
        private static List<TodoItem> todos = new List<TodoItem>()
        {
            new TodoItem() { Title = "Aller faire les courses", Description = "Lait, oignons, crème fraiche", IsDone = false },
            new TodoItem() { Title = "Faire le ménage", Description = "Aspirateur, machine à laver, sol, serpière", IsDone = false },
            new TodoItem() { Title = "Faire du Hip Hop", Description = "Travailler les isolations", IsDone = true }
        };


        /// <summary>
        /// Do the generation of items and go to the list
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var todoItems = todoContext.Todos.ToList();
            if (todoItems == null || todoItems.Count < 1 || todoItems.Count == 0)
            {
                foreach (var todo in todos)
                {
                    todoContext.Todos.Add(todo);
                }
                todoContext.SaveChanges();
            }

            return RedirectToAction("List");
        }


        public IActionResult UpdateTodo(int itemId, bool isDone)
        {
            var todoItem = todoContext.Todos.Find(itemId);
            if (todoItem == null)
                return BadRequest();

            todoItem.IsDone = isDone;
            todoContext.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult View(int id)
        {
            var todoItem = todoContext.Todos.Find(id);
            VmTodoItem model = new VmTodoItem();

            model.Title = todoItem.Title;
            model.Description = todoItem.Description;
            model.IsDone = todoItem.IsDone;

            return View(model);
        }

        /// <summary>
        /// Shows the list of todos in a web page
        /// </summary>
        [HttpGet]
        public IActionResult List()
        {
            VmList model = new VmList();
            var todoItems = todoContext.Todos
                .OrderByDescending(x => x.Id);
            
            model.TodoItemsNotDone = todoItems.Where(x => x.IsDone == false).ToList();
            model.TodoItemsDone = todoItems.Where(x => x.IsDone == true).ToList();

            return View(model); 
        }
    }
}
