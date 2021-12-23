using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollideIdleObject : MonoBehaviour, IGameInitElement
{

    private IGameSystem gameSystem;

    [SerializeField]
    private Entity npc;

    private Trigger triggerComponent;

    public void InitGame(IGameSystem system)
    {
        this.gameSystem = system;

        this.triggerComponent = this.npc.GetEntityComponent<Trigger>();
        this.triggerComponent.OnTriggerEntered += this.OnNPCEntered;
        this.triggerComponent.OnTriggerExited += this.OnNPCExited;
    }

    private void OnNPCEntered(IEntity entity)
    {
        var componen = entity.GetEntityComponent<UnitInfo>();
        if (entity.TryGetEntityComponent(out UnitInfo component) && component.Type == UnitType.IDLE_OBJECT)
        {
            if (entity.TryGetEntityComponent(out AttachingUser userComponent))
            {
                userComponent.TryAttach(this.npc);
            }

        }
    }

    private void OnNPCExited(IEntity entity)
    {
        if (entity.TryGetEntityComponent(out UnitInfo component) && component.Type == UnitType.IDLE_OBJECT)
        {
            if (entity.TryGetEntityComponent(out AttachingUser userComponent))
            {
                userComponent.TryDetachUser(this.npc);
            }
        }
    }

}
