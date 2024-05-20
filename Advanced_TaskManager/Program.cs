using System;
using System.Collections.Generic;
using Advanced_TaskManager.Class;
using Task = Advanced_TaskManager.Class.Task;

<<<<<<< HEAD
using System;
using Advanced_TaskManager.Class;

=======
>>>>>>> 87085245a34a5cf663978afc8b8540a5c7a227bb
namespace Advanced_TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            RegistroUsers registroUsers = new RegistroUsers();
            MenuInteractivo menuInteractivo = new MenuInteractivo();

            registroUsers.MaxAttemptsReached += (sender, e) => Console.WriteLine("Número máximo de intentos alcanzado.");
            registroUsers.UserLoggedIn += (sender, e) => Console.WriteLine("Usuario iniciado sesión correctamente.");
            registroUsers.UserRegistered += (sender, e) => Console.WriteLine("Usuario registrado correctamente.");

            menuInteractivo.ShowMenu(registroUsers);
        }
    }
}

=======
            // Create the user
            User user = new User("admin", "admin");

            // Create the task manager
            TaskManager taskManager = new TaskManager();

            // Subscribe to events
            taskManager.TaskAdded += TaskAddedHandler;
            taskManager.TaskEdited += TaskEditedHandler;

            while (true)
            {
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Edit Task");
                Console.WriteLine("3. List Tasks");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddTask(taskManager);
                            break;
                        case "2":
                            EditTask(taskManager);
                            break;
                        case "3":
                            taskManager.ListTasks();
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        static void AddTask(TaskManager taskManager)
        {
            try
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
                taskManager.AddTask(task);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer for Task ID.");
            }
        }

        static void EditTask()
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

                taskManager.EditTaskByID(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskStatus, taskPriority);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer for Task ID.");
            }
        }

        // Event handler for task added event
        static void TaskAddedHandler(object sender, TaskEventArgs e)
        {
            Console.WriteLine($"Task added: {e.Task.TaskName}");
        }

        // Event handler for task edited event
        static void TaskEditedHandler(object sender, TaskEventArgs e)
        {
            Console.WriteLine($"Task edited: {e.Task.TaskName}");
        }
    }
}
>>>>>>> 87085245a34a5cf663978afc8b8540a5c7a227bb
