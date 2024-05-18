using System;
using System.Collections.Generic;
using Advanced_TaskManager.Class;
using Task = Advanced_TaskManager.Class.Task;

using System;
using Advanced_TaskManager.Class;

namespace Advanced_TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistroUsers registroUsers = new RegistroUsers();
            MenuInteractivo menuInteractivo = new MenuInteractivo();

            registroUsers.MaxAttemptsReached += (sender, e) => Console.WriteLine("Número máximo de intentos alcanzado.");
            registroUsers.UserLoggedIn += (sender, e) => Console.WriteLine("Usuario iniciado sesión correctamente.");
            registroUsers.UserRegistered += (sender, e) => Console.WriteLine("Usuario registrado correctamente.");

            menuInteractivo.ShowMenu(registroUsers);
        }
    }
}

