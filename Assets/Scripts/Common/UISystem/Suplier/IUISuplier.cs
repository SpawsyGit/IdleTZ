using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUISuplier
{
    IUIComponent GetUIPrefab<T>(Transform root);
    void RemoveUIPrefab(IUIComponent prefab);
}
