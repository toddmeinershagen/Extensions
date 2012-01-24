using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        public static List<T> SiblingsAfter<T>(this List<T> list, int currentIndex)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (currentIndex > list.Count - 1 || currentIndex < 0)
                throw new IndexOutOfRangeException();

            return currentIndex == list.Count - 1 ? new List<T>() : list.GetRange(currentIndex + 1, list.Count - currentIndex - 1);
        }

    }
}
