using System;
using System.Collections.Generic;

namespace Reception.Helpers
{
    public static class IndexHelper
    {

        public static int FindIndex<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            int index = 0;
            foreach (var item in items)
            {
                if (predicate(item))
                    break;
                index++;
            }

            return index;

        }

    }
}
