using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectionTesting.Core
{
    public class Projection
    {
        public static TDestination Map<TSource, TDestination>(TSource source, Dictionary<string, string> entityMap)
            where TDestination : new()
        {
            var destination = new TDestination();

            foreach (var (key, value) in entityMap)
            {
                var sourceValue = GetPropertyValue(source, value);
                SetPropertyValue(destination, key, sourceValue);
            }

            return destination;
        }

        public static IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> sources,
            Dictionary<string, string> entityMap) where TDestination : new()
        {
            return sources.Select(source => Map<TSource, TDestination>(source, entityMap)).ToList();
        }

        private static object GetPropertyValue(object obj, string property)
        {
            return obj.GetType().GetProperties()
                .Single(prop => string.Equals(prop.Name, property, StringComparison.CurrentCultureIgnoreCase))
                .GetValue(obj);
        }

        private static void SetPropertyValue(object obj, string property, object value)
        {
            obj.GetType().GetProperties()
                .Single(prop => string.Equals(prop.Name, property, StringComparison.CurrentCultureIgnoreCase))
                .SetValue(obj, value);
        }
    }
}