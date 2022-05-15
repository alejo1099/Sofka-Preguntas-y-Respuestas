using System;

namespace Preguntas_y_Respuestas
{
    [Serializable]
    internal class QuestionData
    {
        public readonly string question;

        public readonly string answer;
        private readonly string[] wrongAnswers;

        public QuestionData(string question, string answer, string[] wrongAnswers)
        {
            this.question = question;
            this.wrongAnswers = wrongAnswers;
            this.answer = answer;
        }
        
        public string[] GetAnswers()
        {
            return new string[4] {wrongAnswers[0], wrongAnswers[1],
                wrongAnswers[2], answer};
        }
    }
}
