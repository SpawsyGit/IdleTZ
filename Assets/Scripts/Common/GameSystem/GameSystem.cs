using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : IGameSystem
{
    private readonly GameElementContext elementContext;

    private readonly GameServiceContext serviceContext;

    public GameSystem()
    {
        this.elementContext = new GameElementContext(this);
        this.serviceContext = new GameServiceContext();
    }

    public void InitGame()
    {
        this.elementContext.InitGame();
    }

    public void AddElement(IGameElement element)
    {
        this.elementContext.AddElement(element);
    }

    public void RemoveElement(IGameElement element)
    {
        this.elementContext.RemoveElement(element);
    }

    public void AddService(object service)
    {
        this.serviceContext.AddService(service);
    }

    public T GetService<T>()
    {
        return this.serviceContext.GetService<T>();
    }

    public void RemoveService(object service)
    {
        this.serviceContext.RemoveService(service);
    }

}
