using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_TaskManager.Class
{
    internal class Task
    {
        public int TaskID { get; private set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public string TaskStatus { get; set; }
        public string TaskPriority { get; set; }

        public Task(int taskID, string taskName, string taskDescription, DateTime taskStartDate, DateTime taskEndDate, string taskStatus, string taskPriority)
        {
            TaskID = taskID;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStartDate = taskStartDate;
            TaskEndDate = taskEndDate;
            TaskStatus = taskStatus;
            TaskPriority = taskPriority;
        }

        public List<string> TaskToList()
        {
            return new List<string> {
                TaskID.ToString(),
                TaskName,
                TaskDescription,
                TaskStartDate.ToString(),
                TaskEndDate.ToString(),
                TaskStatus,
                TaskPriority
            };
        }
    }   
}
