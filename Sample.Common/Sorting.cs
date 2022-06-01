using Sample.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sample.Common
{
    public static class Sorting
    {
        public static List<T> SortData<T>(List<T> data, string sortingParam, SortOrder? sortOrder)
        {
            if (!string.IsNullOrEmpty(sortingParam))
            {
                var column = typeof(T).GetProperty(sortingParam, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                if (column != null)
                {
                    data = sortOrder == SortOrder.Asc ?
                        data.OrderBy(x => column.GetValue(x, null)).ToList() :
                        data.OrderByDescending(x => column.GetValue(x, null)).ToList();
                }
            }

            return data;
        }
    }
}
