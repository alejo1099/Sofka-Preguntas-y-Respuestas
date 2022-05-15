using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Preguntas_y_Respuestas
{
    internal class DataManager
    {
        public readonly UsersContainer usersContainer;
        public readonly QuestionsContainer questionsContainer;

        private readonly string usersFileName = "Users.usr";
        private readonly string questionsFileName = "Questions.qu";

        public DataManager()
        {
            usersContainer = LoadUsersData();
            if (usersContainer == null)
                usersContainer = new UsersContainer();

            questionsContainer = LoadQuestionsData();
            if (questionsContainer == null)
                questionsContainer = new QuestionsContainer();
        }

        private QuestionsContainer LoadQuestionsData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(questionsFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            if (stream.Length == 0)
            {
                stream.Close();
                return null;
            }

            QuestionsContainer container = (QuestionsContainer)formatter.Deserialize(stream);
            stream.Close();

            return container;
        }

        private UsersContainer LoadUsersData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(usersFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            if (stream.Length == 0)
            {
                stream.Close();
                return null;
            }
            UsersContainer container = (UsersContainer)formatter.Deserialize(stream);
            stream.Close();

            return container;
        }

        private void SaveQuestionsData(QuestionsContainer questionsContainer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(questionsFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, questionsContainer);
            stream.Close();
        }

        private void SaveUsersData(UsersContainer usersContainer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(usersFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, usersContainer);
            stream.Close();
        }

        public void SaveData()
        {
            SaveUsersData(usersContainer);
            SaveQuestionsData(questionsContainer);
        }
    }
}