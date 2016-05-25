using AutoID.DataHolders;
using AutoID.ViewModels;
using System;
using System.Data.SqlTypes;

namespace AutoID.Helpers
{
	public static class EntityViewModelConverter
	{
		public static Models.Task Convert(TaskViewModel task)
		{
			return new Models.Task
			{
				AssigneeName = task.AssigneeName,
				ClosedDate = (task.ClosedDate >= (DateTime)SqlDateTime.MinValue) ? task.ClosedDate : (DateTime?)null,
				Comment = task.Comment,
				Id = task.Id,
				IsDone = task.IsDone,
				IssueStatus = (int)task.IssueStatus,
				IssueType = (int)task.IssueType,
				Name = task.Name,
				No = task.No,
				OpenDate = task.OpenDate,
				Priority = (int)task.Priority,
				ReporterName = task.ReporterName,
			};
		}
		public static TaskViewModel Convert(Models.Task task)
		{
			return new TaskViewModel
			{
				AssigneeName = task.AssigneeName,
				ClosedDate = task.ClosedDate,
				Comment = task.Comment,
				Id = task.Id,
				IsDone = task.IsDone,
				IssueStatus = (IssueStatus)task.IssueStatus,
				IssueType = (IssueType)task.IssueType,
				Name = task.Name,
				No = task.No,
				OpenDate = task.OpenDate,
				Priority = (IssuePriority)task.Priority,
				ReporterName = task.ReporterName,
			};
		}
		public static Models.Machine Convert(MachineViewModel machine)
		{
			return new Models.Machine
			{
				Comment =machine.Comment,
				CPUID = machine.CPUID,
				Department = machine.Department,
				HardDriveId = machine.HardDriveId,
				Id = machine.Id,
				MAC = machine.MAC,
				Name = machine.Name,
				OS = machine.OS,
				Owner = machine.Owner,
				Ram = machine.Ram,
			};
		}
		public static MachineViewModel Convert(Models.Machine machine)
		{
			return new MachineViewModel
			{
				Comment = machine.Comment,
				CPUID = machine.CPUID,
				Department = machine.Department,
				HardDriveId = machine.HardDriveId,
				Id = machine.Id,
				MAC = machine.MAC,
				Name = machine.Name,
				OS = machine.OS,
				Owner = machine.Owner,
				Ram = machine.Ram,
			};
		}

	}
}
