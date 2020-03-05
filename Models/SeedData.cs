using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data;

namespace TodoList.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new TodoListContext(serviceProvider.
				GetRequiredService<DbContextOptions<TodoListContext>>()))
			{
				if (context.TodoList.Any())
				{
					return;
				}
				
				context.SaveChanges();
			}
		}
	}
}
