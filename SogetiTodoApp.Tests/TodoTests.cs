using SogetiTodoApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SogetiTodoApp.Tests
{
    [TestClass]
    public class TodoTests
    {
        #region Test Todo List

        [TestMethod]
        public void Get_TodoListRightNumberOk()
        {
            // Arrange
            int numberOfExpectedTodos = 3;
            // Act
            int realTodosNumber = TodoHelper.GenerateTodos().Count;
            // Assert
            Assert.AreEqual(numberOfExpectedTodos, realTodosNumber);
        }

        [TestMethod]
        public void Get_TodoListRightNumberNotOk()
        {
            // Arrange
            int numberOfExpectedTodos = 0;
            // Act
            int realTodosNumber = TodoHelper.GenerateTodos().Count;
            // Assert
            Assert.AreNotEqual(numberOfExpectedTodos, realTodosNumber);
        }

        #endregion

        #region Test Todo Update 

        [TestMethod]
        public void Update_TodoItemStateOk()
        {
            List<TodoItem> _todoItems = TodoHelper.GenerateTodos();

            // Arrange
            string itemName = "Aller faire les courses";
            bool isDone = false;

            // Act
            TodoItem? currentTodoItem = _todoItems.FirstOrDefault(x => x.Title == itemName);
            
            if (currentTodoItem == null)
                currentTodoItem.IsDone = isDone;

            // Assert
            Assert.IsFalse(currentTodoItem.IsDone);
        }

        [TestMethod]
        public void Update_TodoItemStateNotOk()
        {
            List<TodoItem> _todoItems = TodoHelper.GenerateTodos();

            // Arrange
            string itemName = "Aller..zzz faire les courses";
            // Act
            TodoItem? currentTodoItem = _todoItems.FirstOrDefault(x => x.Title == itemName);
            // Assert
            Assert.IsNull(currentTodoItem);
        }

        #endregion

        #region Test Todo Create

        [TestMethod]
        public void Create_NewTodoOk()
        {
            // Arrange
            string expectedName = "testName";
            string expectedDescription = "testDescription";
            bool expectedState = false;

            // Act
            List<TodoItem> todoItems = TodoHelper.GenerateTodos();
            TodoItem todoItem = TodoHelper.AddTodoItem("testName", "testDescription", false);
            todoItems.Add(todoItem);

            bool isFound = false;
            foreach (TodoItem item in todoItems)
            {
                if (item.Title == expectedName && item.Description == expectedDescription
                    && item.IsDone == expectedState)
                {
                    isFound = true;
                }
            }

            // Assert
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void Create_NewTodoNotOk()
        {
            // Arrange
            string expectedName = "testNameZ";
            string expectedDescription = "testDescriptionbbb";
            bool expectedState = true;

            // Act
            List<TodoItem> todoItems = TodoHelper.GenerateTodos();
            TodoItem todoItem = TodoHelper.AddTodoItem("testName", "testDescription", false);
            todoItems.Add(todoItem);

            bool isFound = false;
            foreach (TodoItem item in todoItems)
            {
                if (item.Title == expectedName && item.Description == expectedDescription
                    && item.IsDone == expectedState)
                {
                    isFound = true;
                }
            }

            // Assert
            Assert.IsFalse(isFound);
        }

        #endregion
    }
}
