using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour, IBullet
{
    private bool isDead = false;
    private BulletDataSO _BulletData;

    protected Rigidbody2D rigidBody2D;

    public BulletDataSO BulletData
    {
        get => _BulletData;
        set
        {
            _BulletData = value;
            rigidBody2D = GetComponent<Rigidbody2D>();
            rigidBody2D.drag = BulletData.Friction;
        } 
    }

    public bool IsPlayerOwner {get; set; }

    private void FixedUpdate()
    {
        if (rigidBody2D != null && BulletData != null)
        {
            rigidBody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        var hittable = collision.GetComponent<IHittable>();
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
            hittable?.GetHit(BulletData.Damage, gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(collision);
            hittable?.GetHit(BulletData.Damage, gameObject);
        }
        
        if (IsPlayerOwner && collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
        
    }
    
    private void HitEnemy(Collider2D collision)
    {
        var knockback = collision.GetComponent<IKnockback>();
        
        knockback?.KnockBack(transform.right, BulletData.KnockBackPower, BulletData.KnockBacDelay);
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Instantiate(BulletData.ImpactEnemyPrefab, collision.transform.position + (Vector3) randomOffset,
            Quaternion.identity);
    }

    private void HitObstacle(Collider2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider != null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }
}
