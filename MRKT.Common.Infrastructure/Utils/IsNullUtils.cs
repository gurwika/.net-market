using System;
using System.Linq.Expressions;

namespace MRKT.Common.Infrastructure.Utils
{
    public static class IsNullUtils
    {
        public static bool IsNull<T>(this T root, Expression<Func<T, object>> getter)
        {
            var visitor = new IsNullVisitor
            {
                CurrentObject = root
            };

            visitor.Visit(getter);
            return visitor.IsNull;
        }

        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }

        public static bool IsNotNull<T>(this T obj)
        {
            return obj != null;
        }

        public static string ToObjectName<T>(this T obj)
        {
            if (obj.IsNull())
            {
                return typeof(T).Name;
            }
            return string.Empty;
        }
    }
}
