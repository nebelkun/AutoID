using AutoID.DataHolders;
using AutoID.ViewModels;
using System;
using System.Data.SqlTypes;
using DAL.Entities;

namespace AutoID.Helpers
{
	public static class EntityViewModelConverter
	{
		public static Task Convert(TaskViewModel task)
		{
			return new Task
			{
				AssigneeName = task.AssigneeName,
				ClosedDate = task.ClosedDate >= (DateTime)SqlDateTime.MinValue ? task.ClosedDate : null,
				Comment = task.Comment,
				Id = task.Id,
				IssueStatus = (int)task.IssueStatus,
				IssueType = (int)task.IssueType,
				Name = task.Name,
				No = task.No,
				OpenDate = task.OpenDate,
				Priority = (int)task.Priority,
				ReporterName = task.ReporterName,
			};
		}
		public static TaskViewModel Convert(Task task)
		{
			return new TaskViewModel
			{
				AssigneeName = task.AssigneeName,
				ClosedDate = task.ClosedDate,
				Comment = task.Comment,
				Id = task.Id,
				IssueStatus = (IssueStatus)task.IssueStatus,
				IssueType = (IssueType)task.IssueType,
				Name = task.Name,
				No = task.No,
				OpenDate = task.OpenDate,
				Priority = (IssuePriority)task.Priority,
				ReporterName = task.ReporterName,
			};
		}
		public static Machine Convert(MachineViewModel machine)
		{
			return new Machine
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
		public static MachineViewModel Convert(Machine machine)
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