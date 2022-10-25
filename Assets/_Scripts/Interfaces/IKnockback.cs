using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockback
{
    void KnockBack(Vector2 direction, float power, float duration);
}
