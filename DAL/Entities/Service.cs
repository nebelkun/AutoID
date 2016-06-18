using System;
using System.Collections.Generic;

namespace DAL.Entities
{
	public class Service
	{
		public Guid Id { get; set; }
		public TimeSpan Period { get; set; }
		public string Name { get; set; }
		public string Comment { get; set; }
		public string ReporterName { get; set; }
		public string AssigneeName { get; set; }
		public List<Task> Services { get; set; }
	}
}