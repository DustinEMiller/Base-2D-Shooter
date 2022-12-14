using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    private EnemyAIBrain enemyBrain;

    [field: SerializeField] protected float AttackdDelay { get; private set; } = 1;
    protected bool waitBeforeNextAttack;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);

    protected IEnumerator WaitBeforeAttackCoroutine()
    {
        waitBeforeNextAttack = true;
        yield return new WaitForSeconds(AttackdDelay);
        waitBeforeNextAttack = false;
    }

    protected Player GetTarget()
    {
        return enemyBrain.Target;
    }
}
