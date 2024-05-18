using Advanced_TaskManager.Class;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advanced_TaskManager.Class
{
    internal class registro_users
    {
        public event EventHandler<string> max_int;
        public event EventHandler<string> inicio_ses;
        public event EventHandler<string> regist;
        private List<User>? base_datos;
        string? user;
        string? contra;
        string Nombre_u;
        string Contra_u;
        int int_contra = 0;
        bool ver_user = false;
        bool ver_contra = false;
        bool val_user = false;
        bool val_contra = false;

        public registro_users()
        {
            base_datos = new List<User>();
        }
        public User registro()
        {
            ver_user = false;
            ver_contra = false;
            while (!ver_user)
            {
                Console.WriteLine("Por favor cree un nombre de usuario: ");
                Nombre_u = Console.ReadLine();

                if (Nombre_u.Length == 0)
                {
                    Console.WriteLine("Por favor ingrese un nombre de usuario");
                    continue;
                }

                if (!verf_usuario(Nombre_u, base_datos))
                {
                    Console.WriteLine("El nombre de usuario ya está en uso, por favor cree otro");
                    continue;
                }
                ver_user = true;
            }

            while (!ver_contra)
            {
                Console.WriteLine("Cree una contraseña nueva (debe tener al menos 8 caracteres, un caracter especial y un número):");
                Contra_u = Console.ReadLine();

                if (!verf_contra(Contra_u))
                {
                    Console.WriteLine("La contraseña no cumple con los requisitos.");
                    continue;
                }
                ver_contra = true;
            }
            base_datos.Add(new User(Nombre_u, Contra_u));
            if (regist != null)
            {
                regist(this, "");
            }
            return new User(Nombre_u, Contra_u);
        }
        public bool verf_contra(string contraseña)
        {
            if (contraseña.Length < 8)
            {
                Console.WriteLine("la contraseña debe tener al menos 8 caracteres");
                return false;
            }
            else if (!contraseña.Any(c => char.IsSymbol(c)))
            {
                return false;
            }
            else if (!contraseña.Any(c => char.IsDigit(c)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool verf_usuario(string nombre, List<User> base_datos)
        {
            if (base_datos == null || base_datos.Count == 0)
            {
                return true;
            }
            else
            {
                bool nombreEnUso = false;
                foreach (var usuario in base_datos)
                {
                    if (nombre == usuario.Username)
                    {
                        nombreEnUso = true;
                    }
                }
                return !nombreEnUso;
            }
        }
        public void Guardar_datos(User user)
        {
            base_datos.Add(user);
        }
        public  bool inciar_sesion()
        {

            while (!val_user)
            {
                Console.WriteLine("para iniciar sesion por favor ingrese su usario:");
                user = Console.ReadLine();
                if (verf_cuentica(user) == false)
                {
                    Console.WriteLine("El nombre de usuario no existe, por favor intente de nuevo");
                }
                else
                {
                    val_user = true;
                }
            }
            while (!val_contra)
            {

                Console.WriteLine("ingrese su contraseña:");
                contra = Console.ReadLine();

                if (verf_contrase(contra) == false)
                {
                    Console.WriteLine("Contraseña incorrecta, por favor intente de nuevo");
                    int_contra++;
                    if (int_contra > 3 && max_int != null)
                    {
                        Console.WriteLine("Número máximo de intentos alcanzado. Saliendo del programa.");
                        continue;
                    }
                    if (max_int != null)
                    {
                        max_int(this, "");
                    }
                }
                else
                {
                    val_contra = true;
                    if (inicio_ses != null)
                    {
                        inicio_ses(this, "");
                    }
                }
            }
                return true;

        }
        public bool verf_cuentica(string nombre)
        {

            if (base_datos == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < base_datos.Count; i++)
                {
                    if (nombre != base_datos[i].Username)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool verf_contrase(string contrase)
        {
            for (int i = 0; i < base_datos.Count; i++)
            {
                if (contra != base_datos[i].Password)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
