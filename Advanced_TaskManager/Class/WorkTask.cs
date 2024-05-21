using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_TaskManager.Class
{
	internal class WorkTask : Advanced_TaskManager.Class.Task
	{
		public string ProjectName { get; set; }

		public WorkTask(int taskID, string taskName, string taskDescription, DateTime taskStartDate, DateTime taskEndDate, string taskPriority, string projectName)
			: base(taskID, taskName, taskDescription, taskStartDate, taskEndDate, "Incompleto", taskPriority)
		{
			ProjectName = projectName;
		}

		public override List<string> TaskToList()
		{
			var baseList = base.TaskToList();
			baseList.Add(ProjectName);
			return baseList;
		}
	}

	internal class PersonalTask : Task
	{
		public string Location { get; set; }

		public PersonalTask(int taskID, string taskName, string taskDescription, DateTime taskStartDate, DateTime taskEndDate, string taskPriority, string location)
			: base(taskID, taskName, taskDescription, taskStartDate, taskEndDate, "Incompleto", taskPriority)
		{
			Location = location;
		}

		public override List<string> TaskToList()
		{
			var baseList = base.TaskToList();
			baseList.Add(Location);
			return baseList;
		}
	}
}
