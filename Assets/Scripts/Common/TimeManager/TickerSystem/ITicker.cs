using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITicker : IDisposable
{
    public event Action onTick;
    public event Action<bool> onEnabled;

    public void SetEnabled(bool value);
    public void UpdateTime(float deltaTime);
    public void RemoveTicker();

    public interface Handler
    {
        void RemoveTicker(ITicker ticker);
    }
}
