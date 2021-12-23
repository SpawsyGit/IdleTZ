using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGameServiceGroup : MonoBehaviour, IGameServiceGroup
{
    [SerializeField]
    private MonoBehaviour[] gameServices;

    public IEnumerable<object> GetServices()
    {
        foreach (object service in gameServices)
            yield return service;
    }
}
