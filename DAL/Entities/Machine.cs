using System;

namespace DAL.Entities
{
	public class Machine
	{
		public Guid Id { get; set; }
		public string MAC { get; set; }
		public string Owner { get; set; }
		public string Department { get; set; }
		public string Comment { get; set; }
		public string Name { get; set; }
		public string CPUID { get; set; }
		public string Ram { get; set; }
		public string HardDriveId { get; set; }
		public string OS { get; set; }
	}
}