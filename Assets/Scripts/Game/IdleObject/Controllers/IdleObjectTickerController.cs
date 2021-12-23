using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleObjectTickerController : MonoBehaviour, IGameInitElement
{
    [SerializeField]
    AttachingUser userComponent;
    [SerializeField]
    TickerHolder tickerComponent;
    [SerializeField]
    IdleConfig config;

    private IGameSystem gameSystem;

    public void InitGame(IGameSystem system)
    {
        this.gameSystem = system;
        userComponent.onUserAttached += TickerOnOff;
    }

    private void TickerOnOff(bool value)
    {
        if (tickerComponent.Ticker == null)
        {
            tickerComponent.AddTicker(gameSystem.GetService<ITimeManager>().GetTicker(config.Interval));
            tickerComponent.Ticker.SetEnabled(true);
        }
        tickerComponent.Ticker.SetEnabled(value);
    }
}
