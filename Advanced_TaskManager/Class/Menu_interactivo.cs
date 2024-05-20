using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advanced_TaskManager.Class
{
    internal class MenuInteractivo
    {
        private readonly TaskManager _taskManager;
        private int _menuOption;

        public MenuInteractivo()
        {
            _taskManager = new TaskManager();
        }

        public void ShowMenu(RegistroUsers registroUsers)
        {
            do
            {
                Console.WriteLine("Bienvenido al sistema de administración de tareas");
                Console.WriteLine("¿Qué deseas hacer hoy?");
                Console.WriteLine("--------------------------------------------------------------------\n" +
                    "1. Registrarse \n" +
                    "2. Iniciar Sesion\n" +
                    "3. Salir\n" +
                    "--------------------------------------------------------------------");
                _menuOption = int.Parse(Console.ReadLine());

                switch (_menuOption)
                {
                    case 1:
                        registroUsers.Register();
                        break;

                    case 2:
                        if (registroUsers.Login())
                        {
                            ShowTaskMenu();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            } while (_menuOption != 3);
        }

        private void ShowTaskMenu()
                        {
            while (true)
            {
                            Console.WriteLine("Select an action:");
                            Console.WriteLine("1. Add Task");
                            Console.WriteLine("2. Edit Task");
                            Console.WriteLine("3. List Tasks");
                            Console.WriteLine("4. Exit");
                            Console.Write("Enter your choice: ");

                            string choice = Console.ReadLine();

                                switch (choice)
                                {
                                    case "1":
                        AddTask();
                                        break;
                                    case "2":
                        EditTask();
                                        break;
                                    case "3":
                        _taskManager.ListTasks();
                                        break;
                    case "4":
                        return;
                                    default:
                                        Console.WriteLine("Invalid choice. Please try again.");
                                        break;
                                }
                            }
        }

        private void AddTask()
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

            var task = new Task(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskStatus, taskPriority);
            _taskManager.AddTask(task);
                }

        private void EditTask()
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

            _taskManager.EditTaskByID(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskStatus, taskPriority);
        }
    }
}
