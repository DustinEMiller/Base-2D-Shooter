using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IAgentInput
{
    UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
}
