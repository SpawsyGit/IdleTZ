﻿using System;
using UnityEngine;
public sealed class Entity : MonoBehaviour, IEntity
{
    private GenericDictionary componentMap;

    [SerializeField]
    private Parameters parameters;


    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void AddEntityComponent(object component)
    {
        if (!this.componentMap.Add(component))
        {
            return;
        }
    }

    public void RemoveEntityComponent(object component)
    {
        this.componentMap.Remove(component);
    }

    public T GetEntityComponent<T>()
    {
        return this.componentMap.Get<T>();
    }

    public bool TryGetEntityComponent<T>(out T component)
    {
        return this.componentMap.TryGet(out component);
    }


    private void Awake()
    {
        this.SetupComponentMap();
    }

    private void SetupComponentMap()
    {
        this.componentMap = new GenericDictionary();
        var components = this.parameters.initialComponents;
        for (int i = 0, count = components.Length; i < count; i++)
        {
            var component = components[i];
            if (component != null)
            {
                this.AddEntityComponent(component);
            }
        }
    }

    [Serializable]
    public sealed class Parameters
    {
        [SerializeField]
        public MonoBehaviour[] initialComponents;
    }
}