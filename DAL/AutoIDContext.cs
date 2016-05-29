using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
	public class AutoIDContext : DbContext
	{
		public DbSet<Machine> Machines { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Service> Services { get; set; }
	}
}
