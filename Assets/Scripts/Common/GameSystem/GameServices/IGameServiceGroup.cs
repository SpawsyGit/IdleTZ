using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameServiceGroup
{
    IEnumerable<object> GetServices();
}
