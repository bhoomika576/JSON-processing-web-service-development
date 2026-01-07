using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public static class RandomHelper
    {
        private static readonly Random _rnd = new Random();
        public static int Random(int max)
        {
            if (max <= 0) return 0;
            return _rnd.Next(max);
        }
    }
}
