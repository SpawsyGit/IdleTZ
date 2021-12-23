using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    public UnitType Type
    {
        get { return this.type; }
    }

    [SerializeField]
    private UnitType type;
}
