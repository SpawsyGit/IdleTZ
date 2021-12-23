using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdleObject
{
    public bool AttachUser(IIdleUser user);
    public bool DetachUser(IIdleUser user);
    public bool DetachUserForce();

    public Vector3 GetLootPoint();

}
