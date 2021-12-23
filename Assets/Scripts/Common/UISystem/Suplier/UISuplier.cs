using System;
using System.Collections.Generic;
using UnityEngine;

public class UISuplier : IUISuplier//Вынести функционал в фабрику
{
    private readonly string path = "Prefabs/";

    private readonly Dictionary<Type, GameObject> prefabMap;

    public UISuplier()
    {
        prefabMap = new Dictionary<Type, GameObject>();
        var prefabs = Resources.LoadAll<GameObject>(path);
        foreach (var pref in prefabs)
        {
            var type = pref.GetComponent<IUIComponent>().GetType();
            if (!prefabMap.ContainsKey(type))
                prefabMap.Add(type, pref);

        }
    }

    public IUIComponent GetUIPrefab<T>(Transform root)
    {
        GameObject prefab;
        if (prefabMap.TryGetValue(typeof(T), out prefab))
        {
            var go = GameObject.Instantiate(prefab, root);
            return go.GetComponent<IUIComponent>();
        }
       
        return default;
    }

    public void RemoveUIPrefab(IUIComponent prefab)
    {
        throw new System.NotImplementedException();
    }
}
