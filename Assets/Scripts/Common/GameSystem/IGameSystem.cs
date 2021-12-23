using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSystem
{
    void AddService(object service);

    void RemoveService(object service);

    void AddElement(IGameElement element);
    void RemoveElement(IGameElement element);

    T GetService<T>();

    void InitGame();
}
