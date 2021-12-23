
using System;

public class Ticker : ITicker
{
    private float currentTime;
    private float interval;

    private bool isEnable;

    private ITicker.Handler handler;

    public event Action onTick;
    public event Action<bool> onEnabled;

    public Ticker(ITicker.Handler handler, float interval)
    {
        this.handler = handler;
        this.interval = interval;
        isEnable = true;
    }

    public void SetEnabled(bool value)
    {
        isEnable = value;
        onEnabled?.Invoke(value);
    }
    public void UpdateTime(float deltaTime)
    {
        if (isEnable)
        {
            currentTime += deltaTime;
            if (currentTime > interval)
                Tick();
        }
    }

    public void RemoveTicker()
    {
        if (this.handler != null)
            this.handler.RemoveTicker(this);
    }

    public void Dispose()
    {

    }

    private void Tick()
    {
        onTick?.Invoke();
        currentTime = 0;
    }
}