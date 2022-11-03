using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject muzzle;
    [SerializeField] protected int ammo = 10;
    [SerializeField] protected WeaponDataSO weaponData;
    [SerializeField] private Enemy target;
    [SerializeField] private CooldownSystem cooldownSystem;
    [field: SerializeField] public UnityEvent OnShoot{ get; set; }
    [field: SerializeField] public UnityEvent OnGetTarget{ get; set; }

    private void Update()
    {
        UseWeapon();
        TargetEnemy();
    }

    private void TargetEnemy()
    {
        if (target != null) return;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (Collider2D collider2d in colliders)
        {
            if (collider2d.TryGetComponent<Enemy>(out Enemy enemy) && target == null)
            {
                target = enemy;
                OnGetTarget?.Invoke();
            }
        }
        
    }

    private void UseWeapon()
    {
        if (target && !cooldownSystem.IsOnCoolDown(weaponData.Id))
        {
            OnShoot?.Invoke();
            cooldownSystem.PutOnCoolDown(weaponData);
            for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
            {
                ShootBullet();
            }
        }
    }
    
    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion angle)
    {
        var bulletPrefab = Instantiate(weaponData.BulletData.bulletPrefab, position, angle);
        bulletPrefab.GetComponent<IBullet>().BulletData = weaponData.BulletData;
        bulletPrefab.GetComponent<IBullet>().IsPlayerOwner = true;
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0,0,spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
    
}
