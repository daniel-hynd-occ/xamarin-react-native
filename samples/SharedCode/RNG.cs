using System;

namespace SharedCode
{
    public static class RNG
    {
        static Random Random;

        static RNG()
        {
            Random = new Random();
        }

        public static int Next()
        {
            return Random.Next();
        }
    }
}
