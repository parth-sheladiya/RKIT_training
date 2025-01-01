using BasicToDoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicToDoApi.Controllers
{
    public class TodosController : ApiController
    {
        private static List<ToDo> todos = new List<ToDo>
        {
            new ToDo { Id = 1, Task = "Learn ASP.NET Web API", IsCompleted = false },
            new ToDo { Id = 2, Task = "Build a To-Do App", IsCompleted = false },
           
        };

        [HttpGet]
        public List<ToDo> GetTask()
        {
            return todos;
        }

        [HttpGet]
        public  IHttpActionResult  GetTaskByID(int id)
        {
            var todo = todos.Find(t => t.Id == id);

            if (todo == null)
            {
                return NotFound(); 
            }

            return Ok(todo);
        }

        [HttpPost]
        public IHttpActionResult PostTask(ToDo newTask)
        {
            if(newTask == null)
            {
                return BadRequest("invalid data");
            }

            int newId = todos.Count > 0 ? todos.Max(t => t.Id) + 1 : 1;
            newTask.Id = newId; 
            todos.Add(newTask);

            return Created($"api/todos/{newTask.Id}", newTask);

        }

        [HttpPut]
        public IHttpActionResult PutTask(int id , ToDo updatedTask)
        {
            if(updatedTask == null)
            {
                return BadRequest("task can not be null");
            }

            var existingTask = todos.Find(t =>t.Id == id);
            if(existingTask == null)
            {
                return NotFound();
            }

            existingTask.Task = updatedTask.Task;
            existingTask.IsCompleted = updatedTask.IsCompleted;

            return Ok(existingTask);
        }

        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            var deleteTask = todos.Find(t =>t.Id ==id);
            if(deleteTask == null)
            {
                return NotFound();
            }
            todos.Remove(deleteTask);


            return Ok(deleteTask);
        }


    }
}
