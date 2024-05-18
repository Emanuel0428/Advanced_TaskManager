using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_TaskManager.Class
{
    internal class TaskManager
    {
        //Declaracion de variables
        registro_users registro = new registro_users();
        private List<User> base_datos;
        private List<List<Task>> lista_tareas;
        private Dictionary<string, List<Task>> lista_datos;
        private int contador_regis=0;
        public TaskManager()
        {
            base_datos= new List<User>();
            lista_tareas= new List<List<Task>>();
            lista_datos= new Dictionary<string, List<Task>>();
            lista_tareas.Add(new List<Task>(100));
        }

        // Event declarations
        public event EventHandler<TaskEventArgs> TaskAdded;
        public event EventHandler<TaskEventArgs> TaskEdited;

        public User Registro_u()
        {
            return registro.registro();
        }
        public void Guardar_datos()
        {
            base_datos.Add(Registro_u());
        }
        public void Asignar_llaves()
        {
            contador_regis++;

            lista_datos.Add(base_datos[contador_regis - 1].Username, lista_tareas[contador_regis - 1]);
        }
        public void AddTask(String user)
        {

                Console.WriteLine("Enter Task Details:");
                Console.Write("Task ID: ");
                int taskID = int.Parse(Console.ReadLine());
                Console.Write("Task Name: ");
                string taskName = Console.ReadLine();
                Console.Write("Task Description: ");
                string taskDescription = Console.ReadLine();
                DateTime taskStartDate = DateTime.Now;
                DateTime taskEndDate = DateTime.Now;
                Console.Write("Task Status: ");
                string taskStatus = Console.ReadLine();
                Console.Write("Task Priority: ");
                string taskPriority = Console.ReadLine();

                Task task = new Task(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskStatus, taskPriority);
            lista_datos[user].Add(task);
            OnTaskAdded(task);
        }

        public void Delete_Task()
        {
            Console.WriteLine();
        }

        // En la clase TaskManager
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


        public void ListTasks(User user)
        {
            Console.WriteLine(lista_datos[].)
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
        public void EditTask()
        {
            try
            {
                Console.Write("Enter Task ID to Edit: ");
                int taskID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter New Task Details:");
                Console.Write("Task Name: ");
                string taskName = Console.ReadLine();
                Console.Write("Task Description: ");
                string taskDescription = Console.ReadLine();
                DateTime taskStartDate = DateTime.Now;
                DateTime taskEndDate = DateTime.Now;
                Console.Write("Task Status: ");
                string taskStatus = Console.ReadLine();
                Console.Write("Task Priority: ");
                string taskPriority = Console.ReadLine();

                EditTaskByID(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskStatus, taskPriority);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer for Task ID.");
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

    // Event argument class for task events
    class TaskEventArgs : EventArgs
    {
        public Task Task { get; }

        public TaskEventArgs(Task task)
        {
            Task = task;
        }
    }
}
