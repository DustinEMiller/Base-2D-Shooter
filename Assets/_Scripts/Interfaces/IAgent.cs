using UnityEngine;
using UnityEngine.Events;

public interface IAgent
{
    
    UnityEvent OnGetHit { get; set; }
    UnityEvent OnDie { get; set; }
    int Health { get; set; }
    
}