using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MoveComponent : MonoBehaviour
{
    public float Speed
    {
        get { return this.speed; }
    }

    [SerializeField]
    private float speed;

    [SerializeField]
    private Position positionComponent;



    public void Move(Vector3 moveVector)
    {
        var previousPosition = positionComponent.GetPosition();
        var nextPosition = new Vector3(
            previousPosition.x + this.speed * moveVector.x,
            previousPosition.y,
            previousPosition.z + this.speed * moveVector.z
        );

        positionComponent.SetPosition(nextPosition);
    }
}
