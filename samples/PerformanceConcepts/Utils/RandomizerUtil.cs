namespace PatternsAndConcepts.Utils
{
    using System;
    using System.Collections.Generic;

    public sealed class RandomizerUtil
    {
        private static Random random = new Random();
        public static int Uniform(int n)
        {
            return random.Next(n);
        }
        public static void Shuffle<T>(IList<T> target)
        {
            Shuffle(target, 0, target.Count);
        }
        public static void Shuffle<T>(IList<T> target, int start, int end)
        {

            for (int i = start; i < end; i++)
            {
                int randomIndex = i + Uniform(end - i);
                T temp = target[i];
                target[i] = target[randomIndex];
                target[randomIndex] = temp;
            }
        }

        public static void Shuffle<T>(T[] target)
        {
            Shuffle(target, 0, target.Length);
        }
        public static void Shuffle<T>(T[] target, int start, int end)
        {

            for (int i = start; i < end; i++)
            {
                int randomIndex = i + Uniform(end - i);
                T temp = target[i];
                target[i] = target[randomIndex];
                target[randomIndex] = temp;
            }
        }
    }
}
