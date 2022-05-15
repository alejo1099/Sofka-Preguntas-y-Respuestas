namespace Preguntas_y_Respuestas
{
    internal class PrizesData
    {
        private readonly int[] prizes;

        public PrizesData(int[] prizes)
        {
            if (prizes == null)
                this.prizes = new int[5] {1, 10, 50, 100 ,1000};
            else
                this.prizes = prizes;
        }

        public int GetPrize(int round)
        {
            if (round <= 0 || round > 5)
                return 0;
            return prizes[round - 1];
        }
    }
}
