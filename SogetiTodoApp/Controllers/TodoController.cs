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
        /// Do the generation of items and go to the list
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var todoItems = todoContext.Todos.ToList();
            if (todoItems == null || todoItems.Count < 1 || todoItems.Count == 0)
            {
                var todos = TodoHelper.GenerateTodos();
                foreach (var todo in todos)
                {
                    todoContext.Todos.Add(todo);
                }
                todoContext.SaveChanges();
            }

            return RedirectToAction("List");
        }

        // Create the todo
        public IActionResult Create(VmListAndCreate data)
        {
            if (!string.IsNullOrEmpty(data.Title))
            {
                TodoItem todoItem = TodoHelper.AddTodoItem(data.Title, data.Description, false);
                todoContext.Add(todoItem);
                todoContext.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return BadRequest("Title is required");
            }
        }

        // Update the Todo within the database context
        public IActionResult UpdateTodo(int itemId, bool isDone)
        {
            var todoItem = todoContext.Todos.Find(itemId);
            if (todoItem == null)
                return BadRequest();

            todoItem.IsDone = isDone;
            todoContext.SaveChanges();

            return RedirectToAction("List");
        }

        // View the Item
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
            VmListAndCreate model = new VmListAndCreate();
            var todoItems = todoContext.Todos
                .OrderByDescending(x => x.Id);
            
            model.TodoItemsNotDone = todoItems.Where(x => x.IsDone == false).ToList();
            model.TodoItemsDone = todoItems.Where(x => x.IsDone == true).ToList();

            return View(model); 
        }
    }
}
