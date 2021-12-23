using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntitiesManager
{
    void AddEntity(IEntity entity);
    void RemoveEntity(IEntity entity);
    IEntity GetEntity(int id);
}
