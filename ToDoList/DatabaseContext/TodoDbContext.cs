using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.DatabaseContext
{
	public class TodoDbContext : DbContext
	{
		
			public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
			{
			}

			#region Table
			public DbSet<Todo> TodoList { get; set; }

			#endregion Table
		}
	
}
