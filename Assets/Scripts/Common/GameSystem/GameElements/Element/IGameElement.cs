using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameElement
{
    
}

public interface IGameInitElement : IGameElement
{
    void InitGame(IGameSystem system);
}
public interface IGameElementGroup : IGameElement
{
    IEnumerable<IGameElement> GetElements();
}
