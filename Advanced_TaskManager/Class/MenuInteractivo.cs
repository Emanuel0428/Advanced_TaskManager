using System;
using Advanced_TaskManager.Class;

namespace Advanced_TaskManager.Class
{
    internal class MenuInteractivo
    {
        private readonly TaskManager _taskManager;
        private int _menuOption;

        public MenuInteractivo()
        {
            _taskManager = new TaskManager();
            _taskManager.TaskAdded += TaskManager_TaskAdded;
            _taskManager.TaskEdited += TaskManager_TaskEdited;
        }

        private void TaskManager_TaskAdded(object sender, TaskEventArgs e)
        {
            Console.WriteLine($"Tarea '{e.Task.TaskName}' agregada exitosamente.");
        }

        private void TaskManager_TaskEdited(object sender, TaskEventArgs e)
        {
            Console.WriteLine($"Tarea '{e.Task.TaskName}' editada exitosamente.");
        }

        public void ShowMenu(RegistroUsers registroUsers)
        {
            registroUsers.MaxAttemptsReached += RegistroUsers_MaxAttemptsReached;
            registroUsers.UserLoggedIn += RegistroUsers_UserLoggedIn;
            registroUsers.UserRegistered += RegistroUsers_UserRegistered;

            User currentUser = null;

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
                        currentUser = registroUsers.Register();
                        break;

                    case 2:
                        if (registroUsers.Login(out currentUser))
                        {
                            ShowTaskMenu(currentUser);
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

        private void RegistroUsers_MaxAttemptsReached(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private void RegistroUsers_UserLoggedIn(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private void RegistroUsers_UserRegistered(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private void ShowTaskMenu(User currentUser)
        {
            while (true)
            {
                Console.WriteLine("Selecciona una opción:");
                Console.WriteLine("1. Agregar Tarea de Trabajo");
                Console.WriteLine("2. Agregar Tarea Personal");
                Console.WriteLine("3. Editar Tarea");
                Console.WriteLine("4. Listar Tareas");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese su opción: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWorkTask(currentUser);
                        break;

                    case "2":
                        AddPersonalTask(currentUser);
                        break;

                    case "3":
                        EditTask(currentUser);
                        break;

                    case "4":
                        _taskManager.ListTasks(currentUser);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        break;
                }
            }
        }

        private void AddWorkTask(User currentUser)
        {
            Console.WriteLine("Ingrese los detalles de la tarea de trabajo:");
            Console.Write("ID de Tarea: ");
            int taskID = int.Parse(Console.ReadLine());
            Console.Write("Nombre de Tarea: ");
            string taskName = Console.ReadLine();
            Console.Write("Descripción de Tarea: ");
            string taskDescription = Console.ReadLine();
            DateTime taskStartDate = DateTime.Now;
            DateTime taskEndDate = DateTime.Now;
            Console.Write("Prioridad de Tarea: ");
            string taskPriority = Console.ReadLine();
            Console.Write("Nombre del Proyecto: ");
            string projectName = Console.ReadLine();

            var task = new WorkTask(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskPriority, projectName);
            _taskManager.AddTask(currentUser, task);
        }

        private void AddPersonalTask(User currentUser)
        {
            Console.WriteLine("Ingrese los detalles de la tarea personal:");
            Console.Write("ID de Tarea: ");
            int taskID = int.Parse(Console.ReadLine());
            Console.Write("Nombre de Tarea: ");
            string taskName = Console.ReadLine();
            Console.Write("Descripción de Tarea: ");
            string taskDescription = Console.ReadLine();
            DateTime taskStartDate = DateTime.Now;
            DateTime taskEndDate = DateTime.Now;
            Console.Write("Prioridad de Tarea: ");
            string taskPriority = Console.ReadLine();
            Console.Write("Ubicación: ");
            string location = Console.ReadLine();

            var task = new PersonalTask(taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskPriority, location);
            _taskManager.AddTask(currentUser, task);
        }

        private void EditTask(User currentUser)
        {
            Console.Write("Ingrese el ID de la tarea a editar: ");
            int taskID = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese los detalles de la nueva tarea:");
            Console.Write("Nombre tarea: ");
            string taskName = Console.ReadLine();
            Console.Write("Descripción tarea: ");
            string taskDescription = Console.ReadLine();
            DateTime taskStartDate = DateTime.Now;
            DateTime taskEndDate = DateTime.Now;
            Console.Write("Estado tarea: ");
            string taskStatus = Console.ReadLine();

            // Verifica si taskPriority es nulo y asigna un valor predeterminado en su lugar
            string taskPriority = "Normal";
            if (!string.IsNullOrEmpty(taskPriority))
            {
                taskPriority = Console.ReadLine();
            }

            _taskManager.EditTaskByID(currentUser, taskID, taskName, taskDescription, taskStartDate, taskEndDate, taskStatus, taskPriority);
        }


    }
}
