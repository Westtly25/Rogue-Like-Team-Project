using System;
using System.Reflection;

public readonly struct PropertyOrField
{
    private readonly PropertyInfo propertyInfo;
    private readonly FieldInfo fieldInfo;

    public Type Type => propertyInfo != null ? propertyInfo.PropertyType : fieldInfo.FieldType;

    public bool IsOfType(Type type)
    {
        var currentType = type;
        return currentType == type || type.IsAssignableFrom(currentType);
    }

    public PropertyOrField(PropertyInfo propertyInfo) : this()
    {
        this.propertyInfo = propertyInfo;
    }

    public PropertyOrField(FieldInfo fieldInfo) : this()
    {
        this.fieldInfo = fieldInfo;
    }

    public T GetValue<T>(object container)
    {
        if(propertyInfo != null)
        {
            return (T) propertyInfo.GetValue(container);
        }
        else return (T) fieldInfo.GetValue(container);
    }

    public void SetValue<T>(object container, T value)
    {
        if(propertyInfo != null)
        {
            propertyInfo.SetValue(container, value);
        }
        else fieldInfo.SetValue(container, value);
    }
}