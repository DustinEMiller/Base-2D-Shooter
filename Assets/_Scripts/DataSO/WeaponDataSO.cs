using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponDataSO : ScriptableObject, IHasCoolDown
{
    [field: SerializeField] public BulletDataSO BulletData { get; set; }
    [field: SerializeField] public bool AutomaticFire { get; set; } = false;
    [field: SerializeField] public float CoolDownDuration { get; private set; } = 0.1f;
    [field: SerializeField] [field: Range(0, 10)] public float SpreadAngle { get; set; } = 5;

    [SerializeField] private bool multiBulletShoot = false;
    [SerializeField] [Range(1,10)] private int bulletCount = 1;

    public int Id
    {
        get { return GetInstanceID();}
    }

    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShoot == true)
        {
            return bulletCount;
        }

        return 1;
    }
    
}
