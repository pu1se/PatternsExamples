using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.CollectionExtensions
{
    internal static class Extensions
    {
        public static T AddTo<T>(this T obj, ICollection<T> list)
        {
            list.Add(obj);
            return obj;
        }

        public static bool IsOneOf<T>(this T st, params T[] possibleOptions)
        {
            return possibleOptions.Contains(st);
        }
    }
}
