using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServiceContext
{
    private readonly GenericDictionary serviceMap;

    internal GameServiceContext()
    {

        this.serviceMap = new GenericDictionary();
    }

    internal void AddService(object service)
    {
        this.serviceMap.Add(service);
    }

    internal void RemoveService(object service)
    {
        this.serviceMap.Remove(service);
    }

    internal T GetService<T>()
    {

        return this.serviceMap.Get<T>();

    }
}
