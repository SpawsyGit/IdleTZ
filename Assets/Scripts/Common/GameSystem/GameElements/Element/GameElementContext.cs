using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElementContext
{
    private readonly IGameSystem gameSystem;
    private readonly List<IGameElement> gameElements;

    internal GameElementContext(IGameSystem gameSystem)
    {
        this.gameSystem = gameSystem;
        gameElements = new List<IGameElement>();
    }

    internal void AddElement(IGameElement element)
    {
        this.AddRecursively(element);

    }



    internal void RemoveElement(IGameElement element)
    {
        gameElements.Remove(element);
    }

    internal void InitGame()
    {
        foreach (var element in gameElements)
        {
            if (element is IGameInitElement initElement)
            {
                initElement.InitGame(this.gameSystem);
            }
        }
    }

    private void AddRecursively(IGameElement element)
    {
        if (element is IGameElementGroup elementGroup)
        {
            foreach (var child in elementGroup.GetElements())
            {
                this.AddRecursively(child);
            }
        }
        else 
            gameElements.Add(element);


    }
}
