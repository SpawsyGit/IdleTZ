using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleObjectHealthController : MonoBehaviour, IGameInitElement
{
    [SerializeField]
    Health healthComponent;
    [SerializeField]
    TickerHolder tickerComponent;//TODO: ��� ���� ����� � ���� ������������, ��-���� ������� � ����
    [SerializeField]
    AttachingUser userComponent;// TODO: ^

    private IGameSystem gameSystem;

    public void InitGame(IGameSystem system)
    {
        this.gameSystem = system;
        tickerComponent.OnTickerAdded += TickerAdded;        
    }

    private void TickerAdded(ITicker ticker)
    {
        ticker.onTick += OnTick;
    }

    private void OnTick()
    {
        var damage = userComponent.AttachedUser.GetEntityComponent<UserInfo>().Power;
        healthComponent.GetTick(damage);
    }
}
