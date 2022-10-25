using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField]
    [Range(1,20)]
    private float Distance = 20;

    [SerializeField]
    private LayerMask raycastMask = new LayerMask();

    [field:SerializeField]
    public UnityEvent OnPlayerSpotted { get; set; }
    public override bool MakeADecision()
    {
        var direction = enemyBrain.Target.transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Distance, raycastMask);
        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnPlayerSpotted?.Invoke();
            return true;
        }

        return false;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject && enemyBrain != null && enemyBrain.Target != null)
        {
            Gizmos.color = Color.red;
            var direction = enemyBrain.Target.transform.position - transform.position;
            Gizmos.DrawRay(transform.position,direction.normalized * Distance);
        }
    }
#endif
}
