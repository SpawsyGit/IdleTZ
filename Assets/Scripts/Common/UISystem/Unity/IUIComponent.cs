using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIComponent 
{

}

public interface IUISlider : IUIComponent 
{
    void SetPosition(Vector3 position);
    void SetValue(float value);

    void SetEnable(bool value);
}

public interface IUIButton : IUIComponent
{
    public event Action OnClicked;
}
