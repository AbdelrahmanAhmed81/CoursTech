using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Helpers
{
    public static class IQueryableHelper
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source , string propertyName , bool asc) where T : class
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter , propertyName);
            var propAsObject = Expression.Convert(property , typeof(object));

            var exp = Expression.Lambda<Func<T , object>>(propAsObject , parameter);

            return (asc)
                ? source.OrderBy(exp)
                : source.OrderByDescending(exp);
        }
        public static IQueryable<T> Expand<T>(this IQueryable<T> source , string[] properties) where T : class
        {
            var parameter = Expression.Parameter(typeof(T));
            var result = source;
            foreach (string propertyName in properties)
            {
                if (typeof(T).GetProperty(propertyName) != null)
                {
                    var property = Expression.Property(parameter , propertyName);
                    var exp = Expression.Lambda<Func<T , object>>(property , parameter);
                    result = result.Include(exp);
                }
            }
            return result.AsSplitQuery();
        }
    }
}
