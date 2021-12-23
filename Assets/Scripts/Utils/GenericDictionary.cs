using System.Collections;
using System.Collections.Generic;
using System;

public class GenericDictionary
{
    private readonly Dictionary<Type, object> itemMap;

    public GenericDictionary()
    {
        this.itemMap = new Dictionary<Type, object>();
    }

    public bool Add(object item)
    {
        var type = item.GetType();
        if (this.itemMap.ContainsKey(type))
        {
            return false;
        }

        this.itemMap.Add(type, item);
        return true;
    }

    public bool Remove(object item)
    {
        var type = item.GetType();
        if (!this.itemMap.Remove(type))
        {
            return false;
        }

        return true;
    }

    public T Get<T>()
    {
        var requiredType = typeof(T);
        if (this.itemMap.TryGetValue(requiredType, out var item))
        {
            return (T)item;
        }

        foreach (var key in this.itemMap.Keys)
        {
            if (requiredType.IsAssignableFrom(key))
            {
                return (T)this.itemMap[key];
            }
        }

        throw new Exception($"Item of type {requiredType.Name} is not found!");
    }

    public bool TryGet<T>(out T item)
    {
        var requiredType = typeof(T);
        if (this.itemMap.TryGetValue(requiredType, out var value))
        {
            item = (T)value;
            return true;
        }

        foreach (var key in this.itemMap.Keys)
        {
            if (requiredType.IsAssignableFrom(key))
            {
                item = (T)this.itemMap[key];
                return true;
            }
        }

        item = default;
        return false;
    }

}

