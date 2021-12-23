using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoAICowHarvest : MonoBehaviour, IGameInitElement
{
    [SerializeField]
    Entity[] users; // TODO: С одином тут должен быть интерфейс 

    [SerializeField] Transform cowPoint;

    List<AIMoveBehaviour> behaviours;

    private IGameSystem gameSystem;

    public void InitGame(IGameSystem system)
    {
        this.gameSystem = system;

        behaviours = new List<AIMoveBehaviour>(users.Length);
        foreach (var u in users)
        {

            var behaviour = new AIMoveBehaviour(u, cowPoint.position);
            behaviours.Add(behaviour);
        }
        behaviours[0].ChangeDirection();

        var button = gameSystem.GetService<IUIManager>().GetUIComponent<UIButton>() as UIButton;
        button.OnClicked += ChangeBehaviour;
    }


    private void Update()
    {

        foreach (var b in behaviours)
            b.Process(Time.deltaTime);

    }

    public void ChangeBehaviour()
    {
        foreach (var b in behaviours)
            b.ChangeDirection();
    }


}
