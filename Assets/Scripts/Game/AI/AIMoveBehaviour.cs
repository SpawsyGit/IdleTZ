using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveBehaviour : IAIBehaviour
{
    private MoveComponent targetMoveComponent;
    private Position targetPositionComponent;

    private Vector3 startPoint, endPoint;


    private bool toEnd = true;
    private Vector3 direction;
    private Vector3 destinationPoint;


    public AIMoveBehaviour(IEntity user, Vector3 endPoint)
    {
        targetMoveComponent = user.GetEntityComponent<MoveComponent>();
        targetPositionComponent = user.GetEntityComponent<Position>();

        startPoint = targetPositionComponent.GetPosition();
        this.endPoint = new Vector3 (endPoint.x, 0, endPoint.z);
        UpdateDirection();
    }


    public void ChangeDirection()
    {
        toEnd = !toEnd;
        UpdateDirection();
    }

    public void Process(float deltaTime)
    {
        if (!CheckDestination())
        {
            targetMoveComponent.Move(direction * deltaTime);
        }
    }

    private void UpdateDirection()
    {
        direction = toEnd ? endPoint - startPoint : startPoint - endPoint;
        destinationPoint = toEnd ? endPoint : startPoint;
    }

    private bool CheckDestination()
    {
        var position = targetPositionComponent.GetPosition();
        var distance = Vector3.Distance(position, destinationPoint);
        return distance < 0.3f;
    }
}
