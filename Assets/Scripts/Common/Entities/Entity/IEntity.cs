using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    void SetActive(bool isActive);

    void AddEntityComponent(object component);

    void RemoveEntityComponent(object component);

    bool TryGetEntityComponent<T>(out T component);

    T GetEntityComponent<T>();
}
