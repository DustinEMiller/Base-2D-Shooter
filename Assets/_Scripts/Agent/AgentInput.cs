using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    private Camera mainCamera;

    private bool fireButtonDown = false;
    
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed{ get; set; }
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    
    private void Update()
    {
        GetMovementInput();
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
