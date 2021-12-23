using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    public Action<float> OnHealthChanged;

    private void Awake()
    {
        this.currentHealth = this.maxHealth;
    }

    public void GetTick(float amount)
    {
        this.currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }
}
