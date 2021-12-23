using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager 
{
    IUIComponent GetUIComponent<T>() where T : IUIComponent;

    void HideUIComponent(IUIComponent component);
}
