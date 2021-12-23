using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleObjectUIController : MonoBehaviour, IGameInitElement
{
    [SerializeField]
    TickerHolder tickerComponent;
    [SerializeField]
    Health healthComponent;
    [SerializeField]
    Transform UIPoint;

    private UISlider slider;
    private IGameSystem gameSystem;

    public void InitGame(IGameSystem system)
    {
        this.gameSystem = system;
        tickerComponent.OnTickerAdded += TickerAdded;
        healthComponent.OnHealthChanged += ChangeSliderValue;
    }

    private void TickerAdded(ITicker ticker)
    {
        ticker.onEnabled += EnableSlider;
        
    }

    private void ChangeSliderValue(float value)
    {
        if(slider != null)
        {
            slider.SetValue(value);
        }
    }

    private void EnableSlider(bool value)
    {
        if (slider == null)
        {
            slider = gameSystem.GetService<IUIManager>().GetUIComponent<UISlider>() as UISlider;
            slider.SetPosition(UIPoint.position);
        }

        slider.SetEnable(value);       
    }
}
