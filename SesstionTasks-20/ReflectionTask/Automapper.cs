using System.Reflection;

namespace ReflectionTask;
public class Automapper
{
    public static void Map<TSource2, TDestination>(TSource2 source, TDestination destination)
    {
        var sourceProps = typeof(TSource2).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destProps = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var sourceProp in sourceProps)
        {
            if (!sourceProp.CanRead) continue;

            var destProp = Array.Find(destProps, p => p.Name == sourceProp.Name && p.CanWrite && p.PropertyType == sourceProp.PropertyType);
            if (destProp != null)
            {
                var value = sourceProp.GetValue(source, null);
                destProp.SetValue(destination, value, null);
            }
        }
    }
}