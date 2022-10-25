using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField] 
    private int maxHealth;
    private int health;
    
    [field:SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field:SerializeField]
    public UnityEvent OnDie { get; set; }
    
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0,maxHealth);
            Debug.Log(health);
            uiHealth.UpdateUI(health);
        }
    }

    private bool dead = false;

    private PlayerWeapon playerWeapon;

    [field:SerializeField]
    private UIHealth uiHealth { get; set; }


    private void Awake()
    {
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }

    private void Start()
    {
        uiHealth.Initialize(maxHealth);
        Health = maxHealth;
    }
    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!dead)
        {
            Health-=damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                dead = true;
                OnDie?.Invoke();
                
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = collision.gameObject.GetComponent<Resource>();
            if (resource != null)
            {
                switch (resource.ResourceData.Type)
                {
                    case ResourceType.Health:
                        if (Health >= maxHealth)
                        {
                            return;
                        }
                        Health += resource.ResourceData.GetAmount();
                        resource.PickUpResource();
                        break;
                    case ResourceType.Ammo:
                        if (playerWeapon.AmmoFull)
                        {
                            return;
                        }
                        playerWeapon.AddAmmo(resource.ResourceData.GetAmount());
                        resource.PickUpResource();
                        break;
                }
            }
        }
    }
}
