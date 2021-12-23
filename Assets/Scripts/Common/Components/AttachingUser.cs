using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachingUser : MonoBehaviour
{
    private IEntity attachedUser;
    public IEntity AttachedUser { get => attachedUser; }
    public Action<bool> onUserAttached;

    public bool TryAttach(IEntity user)
    {
        if (attachedUser == null)
        {
            attachedUser = user;
            onUserAttached?.Invoke(true);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryDetachUser(IEntity user)
    {
        if (attachedUser == user)
        {
            attachedUser = null;
            onUserAttached?.Invoke(false);
            return true;
        }
        return false;
    }

    public void DetachUserForce()
    {
        if (attachedUser != null)
        {
            attachedUser = null;
            onUserAttached?.Invoke(false);
        }
    }
}
