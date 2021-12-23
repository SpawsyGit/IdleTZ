using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleHealth 
{
    internal float maxHealth;
    private float currentHealth;

    public IdleHealth(float maxHp)
    {
        this.maxHealth = maxHp;
        this.currentHealth = this.maxHealth;
    }

    internal float GetTick(float amount)
    {
        this.currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = maxHealth;
        return currentHealth;
    }
}
