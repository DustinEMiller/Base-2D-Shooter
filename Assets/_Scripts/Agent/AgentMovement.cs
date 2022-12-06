using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidBody2d;
    [field: SerializeField]public MovementDataSO MovementData { get; set; }
    
    [SerializeField] protected float currentVelocity = 3f;
    protected Vector2 movementDirection;
    protected bool isKnockedBack = false;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        /*if (movementInput.magnitude > 0)
        {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                currentVelocity = 0;
            movementDirection = movementInput.normalized;
        }*/
        if (movementInput.magnitude > 0)
        {
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
        
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        if (!isKnockedBack)
        {
            rigidBody2d.velocity = currentVelocity * movementDirection.normalized;
        }
        
    }

    public void StopImmediately()
    {
        currentVelocity = 0;
        rigidBody2d.velocity = Vector2.zero;
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        if (!isKnockedBack)
        {
            isKnockedBack = true;
            StartCoroutine(KnockBackCoroutine(direction, power, duration));
        }
    }

    public void ResetKnockBack()
    {
        StopCoroutine("KnockBackCoroutine");
        ResetKnockbackParameters();
    }

    private void ResetKnockbackParameters()
    {
        currentVelocity = 0;
        rigidBody2d.velocity = Vector2.zero;
        isKnockedBack = false;
    }

    IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration)
    {
        rigidBody2d.AddForce(direction.normalized*power,ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockbackParameters();
    }
}
