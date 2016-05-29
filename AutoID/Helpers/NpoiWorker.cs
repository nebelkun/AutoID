using System.Collections.Generic;
using System.Data;
using System.IO;
using AutoID.ViewModels;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace AutoID.Helpers
{
	public static class NpoiWorker
	{
		public static void ExportMachineList(string filePath, string fileName, IEnumerable<MachineViewModel> equipmentList)
		{
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());

			DataRow dr = dt.NewRow();
			dr[0] = "Имя компьютера";
			dr[1] = "Комментарий";
			dr[2] = "Закреплён за";
			dr[3] = "MAC";
			dr[4] = "Отдел";
			dr[5] = "Процессор";
			dr[6] = "ОЗУ";
			dr[7] = "HDDID";
			dr[8] = "ОС";
			dr[9] = "ID";
			dt.Rows.Add(dr);

			foreach (MachineViewModel machine in equipmentList)
			{
				dr = dt.NewRow();
				dr[0] = machine.Name;
				dr[1] = machine.Comment;
				dr[2] = machine.Owner;
				dr[3] = machine.MAC;
				dr[4] = machine.Department;
				dr[5] = machine.CPUID;
				dr[6] = machine.Ram;
				dr[7] = machine.HardDriveId;
				dr[8] = machine.OS;
				dr[9] = machine.Id;
				dt.Rows.Add(dr);
			}

			SaveToFile(filePath, fileName, dt);
		}
		public static void ExportTaskList(string filePath, string fileName, IEnumerable<TaskViewModel> taskList)
		{
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());
			dt.Columns.Add(new DataColumn());

			DataRow dr = dt.NewRow();
			dr[0] = "№";
			dr[1] = "Заголовок";
			dr[2] = "Комментарий";
			dr[3] = "Тип заявки";
			dr[4] = "Приоритет";
			dr[5] = "Заявитель";
			dr[6] = "Статус";
			dr[7] = "Дата создания";
			dr[8] = "Дата закрытия";
			dt.Rows.Add(dr);

			foreach (TaskViewModel task in taskList)
			{
				dr = dt.NewRow();
				dr[0] = task.No;
				dr[1] = task.Name;
				dr[2] = task.Comment;
				dr[3] = task.IssueType;
				dr[4] = task.Priority;
				dr[5] = task.ReporterName;
				dr[6] = task.IssueStatus;
				dr[7] = task.OpenDate;
				dr[8] = task.ClosedDate;
				dt.Rows.Add(dr);
			}

			SaveToFile(filePath, fileName, dt);
		}

		static void SaveToFile(string filePath, string fileName, DataTable dt)
		{
			if (!Directory.Exists(filePath))
				Directory.CreateDirectory(filePath);
			using (FileStream stream = new FileStream(Path.Combine(filePath, fileName, ".xlsx"), FileMode.Create, FileAccess.Write))
			{
				IWorkbook wb = new XSSFWorkbook();
				ISheet sheet = wb.CreateSheet("Лист 1");
				ICreationHelper cH = wb.GetCreationHelper();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					IRow row = sheet.CreateRow(i);
					for (int j = 0; j < dt.Columns.Count; j++)
					{
						ICell cell = row.CreateCell(j);
						cell.SetCellValue(cH.CreateRichTextString(dt.Rows[i].ItemArray[j].ToString()));
						sheet.AutoSizeColumn(j);
					}
				}
				wb.Write(stream);
			}
		}
	}
}