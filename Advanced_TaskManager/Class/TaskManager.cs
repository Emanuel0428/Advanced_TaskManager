using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_TaskManager.Class
{
    internal class TaskManager
    {
        private readonly List<Task> taskList;

        public event EventHandler<TaskEventArgs> TaskAdded;
        public event EventHandler<TaskEventArgs> TaskEdited;

        public TaskManager()
        {
            taskList = new List<Task>();
        }

        public void AddTask(Task task)
        {
            taskList.Add(task);
            OnTaskAdded(task);
        }

        public void EditTaskByID(int taskID, string taskName, string taskDescription, DateTime taskStartDate, DateTime taskEndDate, string taskStatus, string taskPriority)
        {
            Task taskToUpdate = taskList.FirstOrDefault(t => t.TaskID == taskID);
            if (taskToUpdate != null)
            {
                taskToUpdate.TaskName = taskName;
                taskToUpdate.TaskDescription = taskDescription;
                taskToUpdate.TaskStartDate = taskStartDate;
                taskToUpdate.TaskEndDate = taskEndDate;
                taskToUpdate.TaskStatus = taskStatus;
                taskToUpdate.TaskPriority = taskPriority;
                OnTaskEdited(taskToUpdate);
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        public void ListTasks()
        {
            foreach (Task task in taskList)
            {
                List<string> taskInfo = task.TaskToList();
                Console.WriteLine($"Task ID: {taskInfo[0]}");
                Console.WriteLine($"Task Name: {taskInfo[1]}");
                Console.WriteLine($"Task Description: {taskInfo[2]}");
                Console.WriteLine($"Task Start Date: {taskInfo[3]}");
                Console.WriteLine($"Task End Date: {taskInfo[4]}");
                Console.WriteLine($"Task Status: {taskInfo[5]}");
                Console.WriteLine($"Task Priority: {taskInfo[6]}");
                Console.WriteLine();
            }
        }

        protected virtual void OnTaskAdded(Task task)
        {
            TaskAdded?.Invoke(this, new TaskEventArgs(task));
        }

        protected virtual void OnTaskEdited(Task task)
        {
            TaskEdited?.Invoke(this, new TaskEventArgs(task));
        }
    }

    class TaskEventArgs : EventArgs
    {
        public Task Task { get; }

        public TaskEventArgs(Task task)
        {
            Task = task;
        }
    }
}
