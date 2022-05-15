namespace Preguntas_y_Respuestas
{
    internal class SaveSystem
    {
        private DataManager dataManager;

        public SaveSystem(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public void Save()
        {
            dataManager.SaveData();
        }
    }
}