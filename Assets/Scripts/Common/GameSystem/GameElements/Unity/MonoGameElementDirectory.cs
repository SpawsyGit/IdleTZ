using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGameElementDirectory : MonoBehaviour, IGameElementGroup
{
    [SerializeField]
    private Transform[] containers;

    private List<IGameElement> elements;

    public IEnumerable<IGameElement> GetElements()
    {
        foreach (var element in elements)
            yield return element;
    }

    private void Awake()
    {
        this.elements = new List<IGameElement>();

        LoadElements();
    }

    private void LoadElements()
    {
        for (int i = 0, count = this.containers.Length; i < count; i++)
        {
            var container = this.containers[i];
            foreach (Transform child in container)
            {
                var element = child.GetComponent<IGameElement>();
                this.elements.Add(element);
            }
        }
    }
}
