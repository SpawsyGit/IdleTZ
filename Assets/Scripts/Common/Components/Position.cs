using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Position : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public Vector3 GetPosition()
    {
        return target.position;
    }

    public void SetPosition(Vector3 position)
    {
        this.target.position = new Vector3(position.x, target.position.y, position.z);
    }
}
