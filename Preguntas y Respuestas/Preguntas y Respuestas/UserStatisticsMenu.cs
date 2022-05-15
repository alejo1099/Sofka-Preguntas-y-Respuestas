using System;
using System.Collections.Generic;

namespace Preguntas_y_Respuestas
{
    internal class UserStatisticsMenu : AbstractScene
    {
        public UserStatisticsMenu(SceneManager sceneManager, UserData userData) : base(sceneManager, userData)
        {
            sceneManager.AddScene(Scenes.UserStatisticsMenu, this);
        }

        public override void OnStartScene()
        {
            ShowStatistics();
            while (true)
            {
                Console.WriteLine("Ingresa E para salir");
                string response = Console.ReadLine();
                response = response.ToLower();
                if(response == "e")
                {
                    Console.Clear();
                    LoadScene(Scenes.MainMenu);
                    return;
                }
                else
                    Console.WriteLine("Valor no valido");
            }
        }

        private void ShowStatistics()
        {
            Console.WriteLine("Bienvenido " + user.userName);
            Console.WriteLine("Estas son todas tus partidas jugadas");
            IEnumerable<Tuple<int, int, string>> games = user.GetUserGamesData();
            if (games == null)
                Console.WriteLine("Aún no tienes partidas jugadas");
            else
            {
                Console.WriteLine(string.Format("Puntaje total: {0}", user.totalScore));
                foreach (var game in games)
                {
                    string infoGame = string.Format("Puntaje: {0}   Ronda Alcanzada: {1}   Fecha : {2}"
                        , game.Item1, game.Item2, game.Item3);
                    Console.WriteLine(infoGame);
                }
            }
        }
    }
}