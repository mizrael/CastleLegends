using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleLegends.Common.Utils
{
    public static class MathUtils
    {
        public static bool IsEven(this int number) {
            return 0 == (number & 1);
        }
    }
}
