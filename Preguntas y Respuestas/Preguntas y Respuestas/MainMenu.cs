using System;

namespace Preguntas_y_Respuestas
{
    internal class MainMenu : AbstractScene
    {
        public MainMenu(SceneManager sceneManager, UserData userData) : base(sceneManager, userData)
        {
            sceneManager.AddScene(Scenes.MainMenu, this);
        }
        
        public override void OnStartScene()
        {
            ShowOptions();
        }

        private void ShowOptions()
        {
            while (true)
            {
                Console.WriteLine("Bienvenido " + user.userName);
                Console.WriteLine("Ingresa I para iniciar el juego");
                Console.WriteLine("Ingresa D para ver tus partidas jugadas");
                Console.WriteLine("Ingresa A para agregar nuevas preguntas");
                Console.WriteLine("Ingresa E para salir de la aplicacion");
                string response = Console.ReadLine();
                response = response.ToLower();

                Console.Clear();
                switch (response)
                {
                    case "i": LoadScene(Scenes.Game); return;
                    case "d": LoadScene(Scenes.UserStatisticsMenu); return;
                    case "a": LoadScene(Scenes.QuestionsMenu); return;
                    case "e": return;
                    default:
                        Console.WriteLine("Entrada no valida");
                        break;
                }
            }
        }
    }
}
