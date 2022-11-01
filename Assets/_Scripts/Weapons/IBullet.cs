using UnityEngine;

public interface IBullet
{
    BulletDataSO BulletData { get; set; } 
    bool IsPlayerOwner { get; set; }
}
