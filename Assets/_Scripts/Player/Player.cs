using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private PlayerWeapon playerWeapon;

    private void Awake()
    {
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }
    
}
