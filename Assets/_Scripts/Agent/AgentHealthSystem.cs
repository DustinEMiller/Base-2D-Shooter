using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentHealthSystem : MonoBehaviour, IHittable
{
    [field: SerializeField] public event EventHandler OnHealthMaxChange;
    [field: SerializeField] public event EventHandler<int> OnDamaged;
    [field: SerializeField] public event EventHandler OnDied;
    [field: SerializeField] public event EventHandler<int> OnHealed;
    [field: SerializeField] public event EventHandler OnHealthInitialized;
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    [SerializeField] private int healthAmount;
    [SerializeField] private int maxHealth;
    [SerializeField] private PlayerStatsSystem playerStatsSystem;
    
    private void Awake()
    {
        healthAmount = maxHealth;
        OnHealthInitialized?.Invoke(this, EventArgs.Empty);
    }

    public void Damage(int damageAmount)
    {
        healthAmount -= damageAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);

        OnGetHit?.Invoke();
        OnDamaged?.Invoke(this, damageAmount);

        if (isDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
            OnDie?.Invoke();
        }
    }

    public void Heal(int healAmount)
    {
        if (healAmount != maxHealth)
        {
            healthAmount += healAmount;
            healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
            OnHealed?.Invoke(this, healAmount);
        }
    }

    public void HealFull()
    {
        healthAmount = maxHealth;
        OnHealed?.Invoke(this, healthAmount);
    }

    public void SetHealthAmountMax(int maxHealth, bool updateHealthAmount)
    {
        if (maxHealth == 0)
        {
            this.maxHealth = healthAmount;
        }
        else
        {
            this.maxHealth = maxHealth;
        }


        if (updateHealthAmount)
        {
            healthAmount = maxHealth;
        }
        
        OnHealthMaxChange?.Invoke(this, EventArgs.Empty);
    }

    public bool IsFullHealth()
    {
        return healthAmount == maxHealth;
    }

    public bool isDead()
    {
        return healthAmount == 0;
    }

    public int GetHealthAmount()
    {
        return healthAmount;
    }

    public int GetHealthAmountMax()
    {
        return maxHealth;
    }

    public float GetHealthAmountNormalized()
    {
        return (float) healthAmount / maxHealth;
    }
    
    public void GetHit(int damage, GameObject damageDealer)
    { 
        Damage(damage);
    }
}