using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IUIButton
{
    public event Action OnClicked;

    [SerializeField]
    private Button button;

    private void OnEnable()
    {
        this.button.onClick.AddListener(this.OnButtonClicked);
    }

    private void OnDisable()
    {
        this.button.onClick.RemoveListener(this.OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        OnClicked?.Invoke();
    }
}
