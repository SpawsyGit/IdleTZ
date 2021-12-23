using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGameElementGroup : MonoBehaviour, IGameElementGroup
{
    [SerializeField]
    private MonoBehaviour[] gameElements;

    private List<IGameElement> elements;
    public IEnumerable<IGameElement> GetElements()
    {
        return this.elements;
    }

    private void Awake()
    {
        this.elements = new List<IGameElement>();
        this.LoadElements();
    }

    private void LoadElements()
    {
        for (int i = 0, count = this.gameElements.Length; i < count; i++)
        {
            var element = this.gameElements[i];
            this.elements.Add((IGameElement)element);
        }
    }
}
