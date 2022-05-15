using System.Collections.Generic;
using System;

namespace Preguntas_y_Respuestas
{
    [Serializable]
    internal class QuestionsContainer
    {
        private List<QuestionData> questionsPrincipiante = new List<QuestionData>();
        private List<QuestionData> questionsAmateur = new List<QuestionData>();
        private List<QuestionData> questionsIntermedio = new List<QuestionData>();
        private List<QuestionData> questionsDificil = new List<QuestionData>();
        private List<QuestionData> questionsGenio = new List<QuestionData>();

        private Random random = new Random();

        public int numberQuestions { get; private set; }

        public bool AddQuestion(QuestionData questionData, Category category)
        {
            if (questionData == null) return false;
            switch(category)
            {
                case Category.Principiante:return CheckListQuestion(questionsPrincipiante, questionData);
                case Category.Amateur: return CheckListQuestion(questionsAmateur, questionData);
                case Category.Intermedio: return CheckListQuestion(questionsIntermedio, questionData);
                case Category.Dificil: return CheckListQuestion(questionsDificil, questionData);
                case Category.Genio: return CheckListQuestion(questionsGenio, questionData);
            }
            return false;
        }

        private bool CheckListQuestion(List<QuestionData> questionsList, QuestionData questionData)
        {
            string questionStr = questionData.question;

            if (ExistQuestion(questionStr, questionsList))
                return false;

            questionsList.Add(questionData);
            numberQuestions++;
            return true;
        }

        public QuestionData GetRandomQuestion(Category category)
        {
            switch (category)
            {
                case Category.Principiante: return GetRandomQuestionData(questionsPrincipiante);
                case Category.Amateur: return GetRandomQuestionData(questionsAmateur);
                case Category.Intermedio: return GetRandomQuestionData(questionsIntermedio);
                case Category.Dificil: return GetRandomQuestionData(questionsDificil);
                case Category.Genio: return GetRandomQuestionData(questionsGenio);
            }
            return null;
        }

        private QuestionData GetRandomQuestionData(List<QuestionData> questionsList)
        {
            if(questionsList == null || questionsList.Count == 0)
                return null;
            return questionsList[random.Next(0, questionsList.Count)];
        }

        public bool ContainsQuestion(string question)
        {
            bool exist = false;
            exist |= ExistQuestion(question, questionsPrincipiante);
            exist |= ExistQuestion(question, questionsAmateur);
            exist |= ExistQuestion(question, questionsIntermedio);
            exist |= ExistQuestion(question, questionsDificil);
            exist |= ExistQuestion(question, questionsGenio);

            return exist;
        }

        private bool ExistQuestion(string question, List<QuestionData> questionsList)
        {
            foreach (var questionDataItem in questionsList)
                if (questionDataItem.question == question)
                    return true;

            return false;
        }
    }
}
