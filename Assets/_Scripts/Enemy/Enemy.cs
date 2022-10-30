using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IKnockback
{
    
    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public EnemyAttack enemyAttack { get; set; }
    private AgentMovement agentMovement;
    private AgentHealthSystem _healthSystem;


    private void Awake()
    {
        if (enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }

        agentMovement = GetComponent<AgentMovement>();
        _healthSystem = GetComponent<AgentHealthSystem>();
        _healthSystem.SetHealthAmountMax(EnemyData.MaxHealth, true);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if (!_healthSystem.isDead())
        {
            enemyAttack.Attack(EnemyData.Damage);
        }
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        agentMovement.KnockBack(direction, power, duration);
    }
}
