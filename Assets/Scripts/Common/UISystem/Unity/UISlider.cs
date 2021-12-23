using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour, IUISlider
{

    [SerializeField]
    Slider slider;

    public void SetEnable(bool value)
    {
        slider.gameObject.SetActive(value);
    }

    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }

    



}
