using System;

namespace Preguntas_y_Respuestas
{
    internal class UserSignMenu
    {
        private UsersContainer usersContainer;
        private SaveSystem saveSystem;

        public UserSignMenu(SaveSystem saveSystem, UsersContainer usersContainer)
        {
            this.usersContainer = usersContainer;
            this.saveSystem = saveSystem;
        }

        public UserData GetUser()
        {
            UserData userData = null;
            while(userData == null)
            {
                Console.WriteLine("Ingresa U, si quieres ingresar un usuario");
                Console.WriteLine("Ingresa C, si quieres crear un usuario nuevo");
                Console.WriteLine("Ingresa E, si salir de la aplicacion");
                
                string response = Console.ReadLine();
                response = response.ToLower();
                ClearConsole();
                if (response == "u")
                    userData = SignInUser();
                else if (response == "c")
                    userData = SignUpUser();
                else if (response == "e")
                    return null;
                else
                    Console.WriteLine("Ingreso no valido");
            }
            return userData;
        }

        private UserData SignInUser()
        {
            Console.WriteLine("Por favor ingrese su nombre de usuario");
            string userName = Console.ReadLine();

            Console.WriteLine("Por favor ingrese su contraseña");
            string password = Console.ReadLine();

            ClearConsole();
            bool rightInput = CheckInput(userName, password);
            if(rightInput)
            {
                if (usersContainer.CheckUserAndPassword(userName, password))
                    return usersContainer.GetUser(userName);
            }
            Console.WriteLine("Tu nombre de usuario y/o contraseña son incorrectos");
            return null;
        }

        private UserData SignUpUser()
        {
            Console.WriteLine("Por favor ingrese su nombre de usuario");
            string userName = Console.ReadLine();

            Console.WriteLine("Por favor ingrese su contraseña");
            string password = Console.ReadLine();

            ClearConsole();
            bool rightInput = CheckInput(userName, password);
            if (rightInput)
            {
                bool userInContainer = usersContainer.CheckUser(userName);
                if (!userInContainer)
                {
                    UserData newUser = usersContainer.SetUser(userName, password);
                    saveSystem.Save();
                    return newUser;
                }
                Console.WriteLine("Ya existe un usuario con ese nombre");
            }
            Console.WriteLine("Tu nombre de usuario y/o contraseña son incorrectos");
            return null;
        }

        private bool CheckInput(string userName, string password)
        {
            if (userName == null || userName.Length == 0) return false;
            if (password== null || password.Length == 0) return false;

            return true;
        }

        private void ClearConsole()
        {
            Console.Clear();
        }
    }
}
