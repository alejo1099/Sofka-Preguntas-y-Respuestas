using System;
using System.Collections.Generic;

namespace Preguntas_y_Respuestas
{
    internal class SceneManager
    {
        private Dictionary<Scenes, AbstractScene> appScenes = new Dictionary<Scenes, AbstractScene>();

        public void AddScene(Scenes sceneType, AbstractScene sceneRef)
        {
            if(!appScenes.ContainsKey(sceneType))
            {
                appScenes.Add(sceneType, sceneRef);
                return;
            }
            Console.WriteLine("Escena ya agregada");
        }

        public void ChangeScene(Scenes nuevaEscena)
        {
            if(appScenes.ContainsKey(nuevaEscena))
            {
                appScenes[nuevaEscena].OnStartScene();
                return;
            }
            Console.WriteLine("Escena no disponible");
        }
    }
}
