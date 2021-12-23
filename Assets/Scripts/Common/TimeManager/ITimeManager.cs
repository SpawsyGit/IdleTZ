using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeManager
{
    public ITicker GetTicker(float interval);
}
