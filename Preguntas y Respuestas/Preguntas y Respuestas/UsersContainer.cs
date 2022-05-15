using System;
using System.Collections.Generic;

namespace Preguntas_y_Respuestas
{
    [Serializable]
    internal class UsersContainer
    {
        private Dictionary<string, UserData> usersList = new Dictionary<string, UserData>();

        public bool CheckUser(string userName)
        {
            if (usersList.ContainsKey(userName))
                return true;

            return false;
        }

        public bool CheckUserAndPassword(string userName, string password)
        {
            if (usersList.ContainsKey(userName))
            {
                if(usersList[userName].CheckPassword(password))
                    return true;
            }
            return false;
        }

        public UserData GetUser(string user)
        {
            if(usersList.ContainsKey(user))
                return usersList[user];
            
            return null;
        }

        public UserData SetUser(string user, string password)
        {
            if (!usersList.ContainsKey(user))
            {
                usersList.Add(user, new UserData(user, password));
                return usersList[user];
            }
            return null;
        }
    }

}
