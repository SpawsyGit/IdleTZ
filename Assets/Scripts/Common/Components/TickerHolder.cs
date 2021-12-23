using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickerHolder : MonoBehaviour
{
    private ITicker ticker;

    public ITicker Ticker { get => ticker; }

    public Action<ITicker> OnTickerAdded;
    public Action OnTickerRemove;

    public bool AddTicker(ITicker ticker)
    {
        if (this.ticker == null)
        {
            this.ticker = ticker;
            OnTickerAdded?.Invoke(this.ticker);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveTicker()
    {
        if (ticker != null)
        {
            ticker.Dispose();
            ticker = null;
            OnTickerRemove?.Invoke();
        }
    }
}
