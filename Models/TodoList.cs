using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
	public class TodoLists
	{
		public int Id { get; set; }
		public string Title { get; set; }
		[DataType(DataType.Date)]
		public DateTime AddedDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime FinishedDate { get; set; }
		public string Descripion { get; set; }
		
		public uint Priority { get; set; }
	}
}
