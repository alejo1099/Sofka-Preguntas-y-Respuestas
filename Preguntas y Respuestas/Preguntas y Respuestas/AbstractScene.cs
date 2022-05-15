namespace Preguntas_y_Respuestas
{
    internal abstract class AbstractScene
    {
        private SceneManager sceneManager;
        protected UserData user;

        public AbstractScene(SceneManager sceneManager, UserData user)
        {
            this.sceneManager = sceneManager;
            this.user = user;
        }

        public virtual void OnStartScene() { }

        protected void LoadScene(Scenes newScene)
        {
            sceneManager.ChangeScene(newScene);
        }
    }
}