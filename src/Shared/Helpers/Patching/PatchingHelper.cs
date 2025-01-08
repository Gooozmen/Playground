namespace Shared.Helpers;

public class PatchingHelper : IPatchingHelper
{
    public void Patch<TSource, TTarget>(TSource source, TTarget target)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (target == null) throw new ArgumentNullException(nameof(target));

        var sourceProperties = typeof(TSource).GetProperties();
        var targetProperties = typeof(TTarget).GetProperties()
            .ToDictionary(p => p.Name, p => p, StringComparer.OrdinalIgnoreCase);

        foreach (var sourceProperty in sourceProperties)
        {
            // Get the property value from the source
            var value = sourceProperty.GetValue(source);

            // If value is null or default, skip updating
            if (value == null || IsDefaultValue(value)) continue;

            // Check if target has a matching property
            if (targetProperties.TryGetValue(sourceProperty.Name, out var targetProperty))
            {
                // Check if the target property can be written to
                if (targetProperty.CanWrite)
                {
                    // Assign the value from the source to the target
                    targetProperty.SetValue(target, value);
                }
            }
        }
    }

    private static bool IsDefaultValue(object value)
    {
        var type = value.GetType();
        return value.Equals(Activator.CreateInstance(type));
    }
}
