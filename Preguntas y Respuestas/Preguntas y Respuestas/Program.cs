namespace Preguntas_y_Respuestas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            UsersContainer usersContainer = dataManager.usersContainer;

            SaveSystem saveSystem = new SaveSystem(dataManager);

            UserData currentUserData = null;
            UserSignMenu userSignMenu = new UserSignMenu(saveSystem, usersContainer);

            currentUserData = userSignMenu.GetUser();

            if (currentUserData == null)
                return;

            QuestionsContainer questionsContainer = dataManager.questionsContainer;

            if (questionsContainer.numberQuestions == 0)
            {
                DefaultQuestions.AddQuestions(questionsContainer);
                saveSystem.Save();
            }
            SceneManager sceneManager = new SceneManager();
            PrizesData prizesData = new PrizesData(new int[5] { 1000, 10000, 100000, 500000, 1000000 });

            AbstractScene mainMenu = new MainMenu(sceneManager, currentUserData);
            AbstractScene questionsMenu = new QuestionsMenu(saveSystem, questionsContainer, sceneManager, currentUserData);
            AbstractScene userStatisticsMenu = new UserStatisticsMenu(sceneManager, currentUserData);
            AbstractScene game = new Game(prizesData, saveSystem, questionsContainer, sceneManager, currentUserData);

            mainMenu.OnStartScene();
        }
    }
}
