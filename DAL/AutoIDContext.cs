using AutoID.Models;
using System.Data.Entity;

namespace DAL
{
	public class AutoIDContext : DbContext
	{
		public DbSet<Machine> Machines { get; set; }
		public DbSet<AutoID.Models.Task> Tasks { get; set; }
	}
}
