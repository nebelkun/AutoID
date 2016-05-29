using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace DAL
{
	public static class MachineWorker
	{

		public static IEnumerable<Machine> ReadAll()
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.Machines
						select m).ToList();
			}
		}


		public static bool RegisterMachine(Machine machine)
		{
			using (var db = new AutoIDContext())
			{
				db.Machines.Add(machine);
				if (db.SaveChanges() >= 0)
				{
					return true;
				}
				return false;
			}
		}

		public static Machine GetMachineByCPU(string cpu)
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.Machines
						where m.CPUID == cpu
						select m).SingleOrDefault();
			}
		}

		public static bool RemoveMachine(Guid id)
		{
			using (var db = new AutoIDContext())
			{
				var machine = (from m in db.Machines
							   where m.Id == id
							   select m).SingleOrDefault();

				if (machine != null)
				{
					db.Machines.Remove(machine);
					if (db.SaveChanges() >= 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool UpdateMachine(Machine machine)
		{
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.Machines
							  where m.Id == machine.Id
							  select m).SingleOrDefault();

				if (entity != null)
				{
					entity.Comment = machine.Comment;
					entity.Department = machine.Department;
					entity.MAC = machine.MAC;
					entity.Name = machine.Name;
					entity.Owner = machine.Owner;
					entity.CPUID = machine.CPUID;
					entity.HardDriveId = machine.HardDriveId;
					entity.OS = machine.OS;
					entity.Ram = machine.Ram;

					if (db.SaveChanges() >= 0)
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}