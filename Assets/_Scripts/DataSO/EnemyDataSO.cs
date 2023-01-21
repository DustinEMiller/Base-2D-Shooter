using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 3;
    [field: SerializeField] public int HealthPerWave { get; private set; } = 3;
    
    [field: SerializeField] public int Damage { get; private set; } = 1;
    [field: SerializeField] public float DamagePerWave { get; private set; } = 1;
    [field: SerializeField] public int AttackDelay{ get; private set; } = 1;
}
