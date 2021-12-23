using UnityEngine;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour, ITimeManager, ITicker.Handler
{

    private readonly List<ITicker> activeTickers = new List<ITicker>();

    public ITicker GetTicker(float interval)
    {
        var ticker = new Ticker(handler: this, interval);
        activeTickers.Add(ticker);
        return ticker;
    }

    void ITicker.Handler.RemoveTicker(ITicker ticker)
    {
        activeTickers.Remove(ticker);
        ticker.Dispose();
    }

    private void Awake()
    {
    }

    private void Update()
    {
        foreach (var ticker in activeTickers)
            ticker.UpdateTime(Time.deltaTime);
    }
}