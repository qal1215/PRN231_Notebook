namespace SE162024.ProductManagement.API.Extensions;

public static class NestedUpdateObject
{
    public static void UpdateObject<T>(this T obj, T updatedObj)
    {
        foreach (var property in typeof(T).GetProperties())
        {
            var value = property.GetValue(updatedObj);
            if (value is not null)
            {
                property.SetValue(obj, value);
            }
        }
    }
}
