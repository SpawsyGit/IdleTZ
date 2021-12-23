using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleObject : MonoBehaviour, IIdleObject, IGameInitElement
{
    [SerializeField]
    private IdleConfig config;
    [SerializeField]
    private Transform UIPoint;

    private ITicker ticker;

    private IGameSystem gameSystem;

    private IIdleUser attachedUser;

    private IdleHealth health;

    private UISlider slider;


    private void Start()
    {   
        
    }

    public bool AttachUser(IIdleUser user)
    {
        if (attachedUser == null)
        {
            attachedUser = user;
            if (ticker == null)
                GetTicker();
            SetEnableTicker(true);
            return true;
        }
        return false;
    }

    public bool DetachUser(IIdleUser user)
    {
        if (attachedUser != null)
        {
            if (user == attachedUser)
            {
                attachedUser = null;
                SetEnableTicker(false);
                return true;
            }
            else
                return false;
        }
        return false;
    }

    public bool DetachUserForce()
    {
        if (attachedUser != null)
        {
            attachedUser = null;
            return true;
        }
        return false;
    }

    public void InitGame(IGameSystem system)
    {
        this.gameSystem = system;
        Debug.Log(gameSystem);
        health = new IdleHealth(config.MaxHealth);
        AttachUser(new IdleUser());
    }

    private void SetEnableTicker(bool value)
    {
        if (ticker != null)
            ticker.SetEnabled(value);
    }

    private void GetTicker()
    {

        ticker = gameSystem.GetService<ITimeManager>().GetTicker(config.Interval);
        ticker.onTick += Tick;
        slider = gameSystem.GetService<IUIManager>().GetUIComponent<UISlider>() as UISlider;
        slider.SetPosition(UIPoint.position);
    }

    private void Tick()
    {
        Debug.Log("tick");
        var currentHp = health.GetTick(attachedUser.Power);
        slider.SetValue(currentHp);
    }

    public Vector3 GetLootPoint()
    {
        throw new System.NotImplementedException();
    }
}
