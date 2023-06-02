using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebpConverter.Data.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : class
        {
            if (source == null)
            {
                return Enumerable.Empty<T>();
            }

            return source.Where(x => x != null)!;
        }
    }
}
