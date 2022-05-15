using System;

namespace Preguntas_y_Respuestas
{
    internal class Game : AbstractScene
    {
        private QuestionsContainer questionsContainer;
        private Random random = new Random();
        private QuestionData currentQuestionData;
        private SaveSystem saveSystem;
        private PrizesData prizesData;

        private string[] currentAnswers;
        private int[] answersOrder;
        private int currentRound = 1;
        private int currentScore = 0;

        public Game(PrizesData prizesData, SaveSystem saveSystem, QuestionsContainer questionsContainer, 
            SceneManager sceneManager, UserData user) : base(sceneManager, user)
        {
            this.questionsContainer = questionsContainer;
            this.saveSystem = saveSystem;
            this.prizesData = prizesData;
            sceneManager.AddScene(Scenes.Game, this);
        }

        public override void OnStartScene()
        {
            currentScore = 0;
            currentRound = 1;
            currentAnswers = null;
            answersOrder = null;
            currentQuestionData = null;
            GameLoop();
        }

        private void GameLoop()
        {
            currentQuestionData = questionsContainer.GetRandomQuestion((Category)currentRound);
            ShowQuestion();
            Console.WriteLine("Ingresa A, B, C, o D para responder");
            Console.WriteLine("Ingresa E, para abandonar el juego");
            Console.WriteLine("Ingresa tu respuesta");
            GetAnswerUser();
        }

        private void ShowQuestion()
        {
            Console.WriteLine(String.Format("Ronda {0}", currentRound));
            Console.WriteLine(currentQuestionData.question);

            currentAnswers = currentQuestionData.GetAnswers();
            answersOrder = MixAnswersOrder();

            Console.WriteLine(string.Format("A: {0}", currentAnswers[answersOrder[0]]));
            Console.WriteLine(string.Format("B: {0}", currentAnswers[answersOrder[1]]));
            Console.WriteLine(string.Format("C: {0}", currentAnswers[answersOrder[2]]));
            Console.WriteLine(string.Format("D: {0}", currentAnswers[answersOrder[3]]));
        }

        private int[] MixAnswersOrder()
        {
            int[] newOrderAnswers = new int[4] {-1, -1, -1, -1};
            int i = 0;
            while(i < 4)
            {
                bool isRepeat = false;
                newOrderAnswers[i] = random.Next(0, 4);
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) continue;
                    if (newOrderAnswers[i] == newOrderAnswers[j])
                    {
                        isRepeat = true;
                        break;
                    }
                }
                if(!isRepeat)
                    i++;
            }
            return newOrderAnswers;
        }

        private void GetAnswerUser()
        {
            while (true)
            {
                string answerUser = Console.ReadLine();
                answerUser = answerUser.ToLower();

                if (answerUser == "e")
                {
                    Console.Clear();
                    AbandonRound();
                    return;
                }

                int answerValue = ConvertAnswer(answerUser);
                if (answerValue == -1)
                {
                    Console.WriteLine("Entrada no valida");
                    continue;
                }
                CheckAnswer(answerValue);
                return;
            }
        }

        private int ConvertAnswer(string userAnswer)
        {
            switch(userAnswer)
            {
                case "a": return 0;
                case "b": return 1;
                case "c": return 2;
                case "d": return 3;
            }
            return -1;
        }

        private void CheckAnswer(int answerValue)
        {
            bool userAnswerIsRight = currentAnswers[answersOrder[answerValue]] == currentQuestionData.answer;

            Console.Clear();
            if (userAnswerIsRight)
                WinRound();
            else
                LoseRound();
        }

        private void WinRound()
        {
            currentScore = prizesData.GetPrize(currentRound);
            currentRound++;

            if (currentRound > 5)
            {
                currentRound = 5;
                WinGame();
                return;
            }

            Console.WriteLine("Respuesta Correcta");
            Console.WriteLine(String.Format("Tu puntaje actual es de {0} de puntos", currentScore));
            Console.WriteLine("¿Quieres continuar a la siguiente ronda, o quieres retirarte?");

            SelectNextGameState();
        }

        private void SelectNextGameState()
        {
            while (true)
            {
                Console.WriteLine("Ingresa C para continar");
                Console.WriteLine("Ingresa E para retirarte");
                string responseUser = Console.ReadLine();
                responseUser = responseUser.ToLower();
                if (responseUser == "c")
                {
                    Console.Clear();
                    GameLoop();
                    return;
                }
                else if (responseUser == "e")
                {
                    Console.Clear();
                    currentRound--;
                    AbandonRound();
                    return;
                }
                Console.WriteLine("Entrada no valida");
            }
        }

        private void LoseRound()
        {
            currentScore = 0;

            Console.WriteLine("Respuesta Incorrecta");
            Console.WriteLine("Game Over");
            Console.WriteLine(String.Format("Ronda alcanzada: {0}", currentRound));
            Console.WriteLine("Puntaje ganado : 0");
            ReturnMainMenu();
        }

        private void AbandonRound()
        {
            Console.WriteLine("Partida abandonada");
            Console.WriteLine(String.Format("Ronda alcanzada: {0}", currentRound));
            Console.WriteLine(String.Format("Puntaje ganado: {0}", currentScore));

            ReturnMainMenu();
        }

        private void WinGame()
        {
            Console.WriteLine("Respuesta Correcta");
            Console.WriteLine("Felicitaciones " + user.userName + ", has ganado el juego");
            Console.WriteLine(String.Format("Tu puntaje total es de {0} puntos", currentScore));

            ReturnMainMenu();
        }

        private void ReturnMainMenu()
        {
            SaveSateGame();
            while (true)
            {
                Console.WriteLine("Ingresa E para salir");
                string response = Console.ReadLine();
                response = response.ToLower();

                if (response == "e")
                {
                    Console.Clear();
                    LoadScene(Scenes.MainMenu);
                    return;
                }
                Console.WriteLine("Entrada no valida");
            }
        }

        private void SaveSateGame()
        {
            string date = DateTime.Now.ToString();
            user.AddGameData(currentScore, currentRound, date);
            saveSystem.Save();
        }
    }
}