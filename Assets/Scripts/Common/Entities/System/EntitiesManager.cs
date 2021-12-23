using System.Collections.Generic;
using UnityEngine;

public class EntitiesManager : MonoBehaviour
{
    private const string ENTITY_TAG = "Entity";
    private readonly Dictionary<int, IEntity> entityMap = new Dictionary<int, IEntity>();
    
    private int idCounter;
    void AddEntity(IEntity entity)
    {
        var id = ++this.idCounter;
        //entity.SetupId(id);
        this.entityMap.Add(id, entity);
    }
    void RemoveEntity(IEntity entity)
    {
        //this.entityMap.Remove(entity.Id);
    }
    IEntity GetEntity(int id)
    {
        return this.entityMap[id];
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag(ENTITY_TAG);
        var count = gameObjects.Length;

        for (var i = 0; i < count; i++)
        {
            var gameObject = gameObjects[i];
            if (gameObject.TryGetComponent(out IEntity entity))
            {
                this.AddEntity(entity);
            }
        }
    }

}