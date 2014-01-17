using System.Collections.Generic;

namespace CastleLegends.Editor.Extensions
{
    public static class IListExtensions
    {
        public static bool Swap<T>(this IList<T> list, int index1, int index2)
        {
            if (index1 < 0 || index1 > list.Count - 1) return false;
            if (index2 < 0 || index2 > list.Count - 1) return false;
            T tempItem = list[index1];
            list[index1] = list[index2];
            list[index2] = tempItem;
            return true;
        }
        
    }
}
