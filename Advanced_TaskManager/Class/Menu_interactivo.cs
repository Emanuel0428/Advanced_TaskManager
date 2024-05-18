using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advanced_TaskManager.Class
{
    internal class Menu_interactivo
    {
        TaskManager taskManager = new TaskManager();
        int numero;
        public void Interactive_Menu(registro_users regis)
        {
            do
            {
                Console.WriteLine("Bienvenido al inicio de la pipipagina");
                Console.WriteLine("que desdeas hacer hoy?");
                Console.WriteLine("--------------------------------------------------------------------\n" +
                    "1. Registrarse \n" +
                    "2. Iniciar Sesion\n" +
                    "3. Salir\n" +
                    "--------------------------------------------------------------------");
                numero = int.Parse(Console.ReadLine());
                switch (numero)
                {
                    case 1:
                        regis.registro();
                        break;

                    case 2:
                        regis.inciar_sesion();

                        //revisar logica del do while
                        while (regis.inciar_sesion()==true)
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
                                        taskManager.AddTask();
                                        break;
                                    case "2":
                                        taskManager.EditTask();
                                        break;
                                    case "3":
                                        taskManager.ListTasks();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice. Please try again.");
                                        break;
                                }
                            }
                        break;
                }
            } while (numero != 4);
        }
    }
}
