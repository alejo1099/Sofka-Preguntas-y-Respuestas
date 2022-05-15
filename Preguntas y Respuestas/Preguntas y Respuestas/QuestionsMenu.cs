using System;

namespace Preguntas_y_Respuestas
{
    internal class QuestionsMenu : AbstractScene
    {
        private QuestionsContainer questionsContainer;
        private SaveSystem saveSystem;

        public QuestionsMenu(SaveSystem saveSystem, QuestionsContainer questionsContainer, 
                SceneManager sceneManager, UserData userData) : base(sceneManager, userData)
        {
            this.questionsContainer = questionsContainer;
            this.saveSystem = saveSystem;
            sceneManager.AddScene(Scenes.QuestionsMenu, this);
        }

        public override void OnStartScene()
        {
            while(true)
            {
                Console.WriteLine("Ingresa A para agregar una nueva pregunta");
                Console.WriteLine("Ingresa M para volver al Menu de Inicio");
                string response = Console.ReadLine();
                Console.Clear();
                response = response.ToLower();

                if (response == "a")
                {
                    AddQuestion();
                    break;
                }
                else if (response == "m")
                {
                    LoadScene(Scenes.MainMenu);
                    break;
                }
                Console.WriteLine("Input Incorrecto");
            }
        }

        private void AddQuestion()
        {
            QuestionData questionData = RequestQuestion();

            if(questionData == null)
            {
                OnStartScene();
                return;
            }
            Category category = RequestCategory();
            if(category == 0)
            {
                OnStartScene();
                return;
            }

            Console.Clear();

            bool questionAdded = questionsContainer.AddQuestion(questionData, category);
            if (questionAdded)
            {
                saveSystem.Save();
                Console.WriteLine("Pregunta agregada correctamente");
            }
            else
                Console.WriteLine("Pregunta ya existente");
            OnStartScene();
        }

        private QuestionData RequestQuestion()
        {
            Console.WriteLine("Ingresa tu pregunta");
            string question = Console.ReadLine();
            Console.WriteLine("Ingresa la respuesta");
            string answer = Console.ReadLine();

            Console.WriteLine("Ingresa una respuesta incorrecta");
            string wrongAnswerOne = Console.ReadLine();
            Console.WriteLine("Ingresa otra respuesta incorrecta");
            string wrongAnswerTwo = Console.ReadLine();
            Console.WriteLine("Ingresa una ultima respuesta incorrecta");
            string wrongAnswerThree = Console.ReadLine();

            Console.Clear();

            if (CheckUserInputs(new string[5]{question, answer,
                wrongAnswerOne, wrongAnswerTwo, wrongAnswerThree}))
            {
                return new QuestionData(question, answer,
                    new string[3] { wrongAnswerOne, wrongAnswerTwo, wrongAnswerThree });
            }
            else
            {
                Console.WriteLine("Alguno de tus valores no fueron validos, tu pregunta no fue guardada");
                return null;
            }
        }

        private bool CheckUserInputs(string[] inputs)
        {
            if (inputs == null)
                return false;
            foreach(string input in inputs)
                if (input == null || input.Length == 0)
                    return false;
            return true;
        }

        private Category RequestCategory()
        {
            while (true)
            {
                Console.WriteLine("Agrega una categoria");
                Console.WriteLine("Ingresa 1 si es Principiante");
                Console.WriteLine("Ingresa 2 si es Amateur");
                Console.WriteLine("Ingresa 3 si es Intermedio");
                Console.WriteLine("Ingresa 4 si es Dificil");
                Console.WriteLine("Ingresa 5 si es Genio");
                Console.WriteLine("Ingresa E si quieres cancelar y volver al menu anterior");
                string response = Console.ReadLine();

                Console.Clear();
                int value = 0;
                bool categoryGot = int.TryParse(response, out value);
                if (categoryGot && value > 0 && value <= 5)
                    return (Category)value;
                else if (!categoryGot && response.ToLower() == "e")
                    return 0;
                else
                    Console.WriteLine("Valor no valido, por favor ingrese nuevamente");
            }
        }
    }
}
