namespace Preguntas_y_Respuestas
{
    internal class DefaultQuestions
    {
        public static void AddQuestions(QuestionsContainer questionsContainer)
        {
            //1
            string question = "¿Cuál es el río más largo del mundo?";
            string answer = "Amazonas";
            string[] wrongAnswers = new string[3]
                {"Nilo", "Congo", "Missisipi" };
            QuestionData questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Principiante);

            //2
            question = "¿Cómo se llama la Reina del Reino Unido?";
            answer = "Isabel II";
            wrongAnswers = new string[3]
                {"Victoria II", "Isabel I", "Diana I" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Principiante);

            //3
            question = "¿En qué continente está Ecuador?";
            answer = "America";
            wrongAnswers = new string[3]
                {"Europa", "Africa", "Asia" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Principiante);

            //4
            question = "¿Quién es el autor de el Quijote?";
            answer = "Miguel de Cervantes";
            wrongAnswers = new string[3]
                { "Dante Alighieri", "William Shakespare", "Gabriel Garcia Marquez" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Principiante);

            //5
            question = "¿Dónde se encuentra la famosa Torre Eiffel?";
            answer = "París";
            wrongAnswers = new string[3]
                { "Roma", "Venecia", "Marsella" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Principiante);



            //6
            question = "¿Cuál es el lugar más frío de la tierra?";
            answer = "Antártida";
            wrongAnswers = new string[3]
                {"Polo Norte", "Groenlandia", "Himalaya" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Amateur);

            //7
            question = "¿Quién escribió La Odisea?";
            answer = "Homero";
            wrongAnswers = new string[3]
                {"Platon", "Dante Alighieri", "Miguel De Cervantes" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Amateur);

            //8
            question = "¿Dónde se originaron los juegos olímpicos?";
            answer = "Grecia";
            wrongAnswers = new string[3]
                { "Italia", "Francia", "Reino Unido" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Amateur);

            //9
            question = "¿En qué país se usó la primera bomba atómica en combate?";
            answer = "Japón";
            wrongAnswers = new string[3]
                { "Estados Unidos", "Rusia", "Corea del Norte" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Amateur);

            //10
            question = "¿Cuál es el océano más grande?";
            answer = "Pacífico";
            wrongAnswers = new string[3]
                { "Atlantico", "Indico", "Oceano Glacial Antartico" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Amateur);



            //11
            question = "¿Cómo se llama la capital de Mongolia?";
            answer = "Ulan Bator";
            wrongAnswers = new string[3]
                {"Seul", "Pyonjang", "Shangai" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Intermedio);

            //12
            question = "¿Cuándo acabó la II Guerra Mundial?";
            answer = "1945";
            wrongAnswers = new string[3]
                { "1939", "1918", "1950" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Intermedio);

            //13
            question = "¿Quién pintó “la última cena”?";
            answer = "Leonardo da Vinci";
            wrongAnswers = new string[3]
                { "Miguel Angel", "Fernando Lutero", "Pablo Picasso" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Intermedio);

            //14
            question = "¿Qué son los humanos?";
            answer = "Omnivoros";
            wrongAnswers = new string[3]
                { "Carnivoros", "Herbívoros", "Insectivoros" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Intermedio);

            //15
            question = "¿Cuál es tercer planeta en el sistema solar?";
            answer = "Tierra";
            wrongAnswers = new string[3]
                { "Marte", "Venus", "Mercurio" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Intermedio);



            //16
            question = "¿Qué cantidad de huesos hay en el cuerpo humano?";
            answer = "206";
            wrongAnswers = new string[3]
                { "204", "196", "210" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Dificil);

            //17
            question = "¿Qué producto cultiva más Guatemala?";
            answer = "Café";
            wrongAnswers = new string[3]
                { "Banano", "Chocolate", "Piña" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Dificil);

            //18
            question = "¿En qué lugar del cuerpo se produce la insulina?";
            answer = "Páncreas";
            wrongAnswers = new string[3]
                { "Higado", "Estomago", "Riñon" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Dificil);

            //19
            question = "¿Cuál fue el primer metal que empleó el hombre?";
            answer = "Cobre";
            wrongAnswers = new string[3]
                { "Hierro", "Acero", "Bronce" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Dificil);

            //20
            question = "¿A qué país pertenece la ciudad de Varsovia?";
            answer = "Polonia";
            wrongAnswers = new string[3]
                { "Hungria", "Moldavia", "Croacia" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Dificil);



            //21
            question = "¿Quién es el padre del psicoanálisis?";
            answer = "Sigmund Freud";
            wrongAnswers = new string[3]
                { "Friederich Nietze", "Albert Einstein", "Isaac Newton" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Genio);

            //22
            question = "¿Cómo se llama la estación espacial rusa?";
            answer = "Mir";
            wrongAnswers = new string[3]
                { "Zenith", "Moscu", "Stallingrado" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Genio);

            //23
            question = "¿Qué es más pequeño?";
            answer = "Átomo";
            wrongAnswers = new string[3]
                { "Molécula", "Celula", "Proteina" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Genio);

            //24
            question = "¿Cuál es el metal más caro del mundo?";
            answer = "Rodio";
            wrongAnswers = new string[3]
                { "Oro", "Platino", "Uranio" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Genio);

            //25
            question = "¿Cuáles son los dos países con mayor cantidad de musulmanes?";
            answer = "Indonesia e India";
            wrongAnswers = new string[3]
                { "Arabia Saudi y Emiratos Arabes Unidos", "Iran y Pakistan", "Turkia y Siria" };
            questionData = new QuestionData(question, answer, wrongAnswers);

            questionsContainer.AddQuestion(questionData, Category.Genio);
        }
    }
}