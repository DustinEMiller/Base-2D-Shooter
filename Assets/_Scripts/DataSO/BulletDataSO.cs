using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/BulletData")]
public class BulletDataSO : ScriptableObject
{
    [field:SerializeField]
    public GameObject bulletPrefab { get; set; }
    
    [field: SerializeField]
    [field: Range(1, 100)]
    public float BulletSpeed { get; set; } = 100;

    [field: SerializeField] 
    public int Damage { get; set; } = 1;
    
    [field: SerializeField]
    public float Friction { get; set; }
    
    [field: SerializeField]
    public bool Bounce { get; set; } = false;

    [field: SerializeField]
    public bool GoThroughHittable { get; set; } = false;

    [field: SerializeField] public bool IsRaycast { get; set; } = false;

    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }
    
    [field: SerializeField]
    public GameObject ImpactEnemyPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 20)]
    public float KnockBackPower { get; set; }
    
    [field: SerializeField]
    [field: Range(0.01f, 1f)]
    public float KnockBacDelay { get; set; }
    
    
    
}
