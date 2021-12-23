using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleUser : MonoBehaviour, IIdleUser
{
    public float Power => power;
    private float power;

    public IdleUser()
    {
        power = 1;
    }
}
