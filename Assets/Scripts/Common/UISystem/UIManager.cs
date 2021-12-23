using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField]
    Transform uiRoot;

    private IUISuplier suplier;
    private void Awake()
    {
        suplier = new UISuplier();  
    }
    public IUIComponent GetUIComponent<T>() where T : IUIComponent
    {
        return suplier.GetUIPrefab<T>(uiRoot);
    }

    public void HideUIComponent(IUIComponent component)
    {
        suplier.RemoveUIPrefab(component);
    }
}
