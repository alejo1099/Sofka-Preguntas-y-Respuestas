using System.Collections.Generic;
using System;

namespace Preguntas_y_Respuestas
{
    [Serializable]
    internal class UserData
    {
        public readonly string userName;
        private readonly string password;

        
        private List<Tuple<int, int, string>> userGameData = new List<Tuple<int, int, string>>();

        public int totalScore { get; private set; }

        public UserData(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public bool CheckPassword(string password)
        {
            if(password == this.password)
                return true;
            return false;
        }

        public void AddGameData(int score, int round, string date)
        {
            totalScore += score;
            userGameData.Add(new Tuple<int, int, string>(score,round, date));
        }

        public IEnumerable<Tuple<int, int, string>> GetUserGamesData()
        {
            if (userGameData.Count == 0)
                return null;
            Tuple<int, int, string>[] userGameDataCopy = new Tuple<int, int, string>[userGameData.Count];
            userGameData.CopyTo(userGameDataCopy);
            return userGameDataCopy;
        }
    }

}
