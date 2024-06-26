﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_TaskManager.Class
{
    internal class RegistroUsers
    {
        // Declaración de eventos
        public event EventHandler<string> MaxAttemptsReached;
        public event EventHandler<string> UserLoggedIn;
        public event EventHandler<string> UserRegistered;

        private readonly List<User> _database;
        private int _loginAttempts;

        public RegistroUsers()
        {
            _database = new List<User>();
        }

        public User Register()
        {
            string username;
            string password;

            while (true)
            {
                Console.WriteLine("Por favor cree un nombre de usuario: ");
                username = Console.ReadLine();

                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Por favor ingrese un nombre de usuario");
                    continue;
                }

                if (IsUsernameAvailable(username))
                {
                    break;
                }

                Console.WriteLine("El nombre de usuario ya está en uso, por favor cree otro");
            }

            while (true)
            {
                Console.WriteLine("Cree una contraseña nueva (debe tener al menos 8 caracteres, un caracter especial y un número):");
                password = Console.ReadLine();

                if (IsValidPassword(password))
                {
                    break;
                }

                Console.WriteLine("La contraseña no cumple con los requisitos.");
            }

            var newUser = new User(username, password);
            _database.Add(newUser);
            UserRegistered?.Invoke(this, $"Usuario {username} registrado exitosamente.");
            return newUser;
        }

        public bool Login(out User loggedInUser)
        {
            string username;
            string password;

            loggedInUser = null;

            while (true)
            {
                Console.WriteLine("Para iniciar sesion por favor ingrese su usuario:");
                username = Console.ReadLine();

                if (IsUsernameValid(username))
                {
                    break;
                }

                Console.WriteLine("El nombre de usuario no existe, por favor intente de nuevo");
            }

            while (true)
            {
                Console.WriteLine("Ingrese su contraseña:");
                password = Console.ReadLine();

                if (IsPasswordValid(username, password))
                {
                    loggedInUser = _database.First(u => u.Username == username);
                    UserLoggedIn?.Invoke(this, $"Usuario {username} inició sesión exitosamente.");
                    return true;
                }

                Console.WriteLine("Contraseña incorrecta, por favor intente de nuevo");
                _loginAttempts++;

                if (_loginAttempts > 3)
                {
                    MaxAttemptsReached?.Invoke(this, "Número máximo de intentos alcanzado.");
                    Console.WriteLine("Número máximo de intentos alcanzado. Saliendo del programa.");
                    return false;
                }
            }
        }

        private bool IsUsernameAvailable(string username)
        {
            return !_database.Any(user => user.Username == username);
        }

        private static bool IsValidPassword(string password) => password.Length >= 8 && password.Any(char.IsSymbol) && password.Any(char.IsDigit);

        private bool IsUsernameValid(string username) => _database.Any(user => user.Username == username);

        private bool IsPasswordValid(string username, string password)
        {
            var user = _database.FirstOrDefault(u => u.Username == username);
            return user != null && user.VerifyPassword(password);
        }
    }
}
