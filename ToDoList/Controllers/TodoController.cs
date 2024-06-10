using Microsoft.AspNetCore.Mvc;
using ToDoList.DatabaseContext;
using ToDoList.Entity;

namespace ToDoList.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly TodoDbContext _db;
		public TodoController(TodoDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		[Route ("viewList")]
		public dynamic Get()
		{
			try
			{

				IQueryable<Todo> todos = _db.TodoList;
				return todos.ToList();
			}
			catch (Exception ex)
			{
				return ex;
			};
		}

		
		[HttpPost]
		[Route("newlist")]
		public dynamic Post( Todo value)
		{
			try
			{
				var Todo = new Todo
				{
					Task = value.Task,
					IsCompleted = value.IsCompleted
				};
				_db.TodoList.Add(Todo);
				_db.SaveChanges();
				return Todo;

			}
			catch (Exception ex)
			{
				return ex;
			}
		}

		
		[HttpPut("{id}")]
		[Route("updateList")]
		public dynamic Put(int id,  Todo value)
		{
			try
			{
				var result=_db.TodoList.FirstOrDefault(x => x.Id == id);
				if (result == null)
				{
					return 404;
				}
				result.Task = value.Task;
				result.IsCompleted = value.IsCompleted;

				_db.TodoList.Update(result);
				_db.SaveChanges();
				return 200;

			}
			catch (Exception ex)
			{ 
				return ex;
			}
		}

	
		[HttpDelete("{id}")]
		public dynamic Delete(int id)
		{
			var result = _db.TodoList.FirstOrDefault(y => y.Id == id);
			if(result == null)
			{
				return 404;
			}
			_db.TodoList.Remove(result);
			_db.SaveChanges();
			return 200;

		}
	}
}
