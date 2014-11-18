namespace TeamTaskboard.Common
{
    using System;

    public class RandomGenerator
    {
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}
