using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_TaskManager.Class
{
    internal class TaskManager
    {
        // Declaración de eventos
        public event EventHandler<TaskEventArgs> TaskAdded;
        public event EventHandler<TaskEventArgs> TaskEdited;

        public void AddTask(User user, Task task)
        {
            user.TaskList.Add(task);
            OnTaskAdded(task);
        }

        public void EditTaskByID(User user, int taskID, string taskName, string taskDescription, DateTime taskStartDate, DateTime taskEndDate, string taskStatus, string taskPriority)
        {
            Task taskToUpdate = user.TaskList.FirstOrDefault(t => t.TaskID == taskID);
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
                Console.WriteLine("¡Tarea no encontrada!");
            }
        }

        public void ListTasks(User user)
        {
            foreach (Task task in user.TaskList)
            {
                List<string> taskInfo = task.TaskToList();
                Console.WriteLine($"ID de Tarea: {taskInfo[0]}");
                Console.WriteLine($"Nombre de Tarea: {taskInfo[1]}");
                Console.WriteLine($"Descripción de Tarea: {taskInfo[2]}");
                Console.WriteLine($"Fecha de Inicio: {taskInfo[3]}");
                Console.WriteLine($"Fecha de Fin: {taskInfo[4]}");
                Console.WriteLine($"Estado: {taskInfo[5]}");
                Console.WriteLine($"Prioridad: {taskInfo[6]}");

                if (task is WorkTask workTask)
                {
                    Console.WriteLine($"Nombre del Proyecto: {workTask.ProjectName}");
                }
                else if (task is PersonalTask personalTask)
                {
                    Console.WriteLine($"Ubicación: {personalTask.Location}");
                }

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

    // Clase de argumentos de evento para eventos de tarea
    class TaskEventArgs : EventArgs
    {
        public Task Task { get; }

        public TaskEventArgs(Task task)
        {
            Task = task;
        }
    }
}
