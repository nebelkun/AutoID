using System;

namespace DAL.Entities
{
	public class SparePart
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Article { get; set; }
		public int Quantity { get; set; }
	}
}
