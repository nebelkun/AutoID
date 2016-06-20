using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
	public class AutoIDContext : DbContext
	{
		public DbSet<Machine> Machines { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<SparePart> SpareParts { get; set; }
		public DbSet<Config> Configs { get; set; }
	}
}
