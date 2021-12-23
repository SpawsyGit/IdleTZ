using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGameSystem : MonoBehaviour, IGameSystem
{
    [SerializeField]
    private MonoBehaviour[] gameServices;
    [Space]
    [SerializeField]
    private MonoBehaviour[] gameElements;

    private IGameSystem gameSystem;

    private void Start()
    {
        this.gameSystem = new GameSystem();
        LoadGameElements();
        LoadServices();
        InitGame();
    }

    private void LoadGameElements()
    {
        for (int i = 0, count = this.gameElements.Length; i < count; i++)
        {
            var element = this.gameElements[i];
            if (element is IGameElement gameElement)
            {
                this.AddElement(gameElement);
            }
        }
    }

    private void LoadServices()
    {
        for (int i = 0, count = this.gameServices.Length; i < count; i++)
        {
            var service = this.gameServices[i];
            if (service != null)
            {
                this.AddService(service);
            }
        }
    }

    public void InitGame()
    {
        this.gameSystem.InitGame();
    }

    public void AddElement(IGameElement element)
    {
        this.gameSystem.AddElement(element);
    }

    public void RemoveElement(IGameElement element)
    {
        this.gameSystem.RemoveElement(element);
    }

    public void AddService(object service)
    {
        this.gameSystem.AddService(service);
    }

    public T GetService<T>()
    {
        return this.gameSystem.GetService<T>();
    }

    public void RemoveService(object service)
    {
        this.gameSystem.RemoveService(service);
    }


}
