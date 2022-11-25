using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerStatsSystem : MonoBehaviour
{
    [Required] [SerializeField] private PlayerStatsDataHolder playerStatsDataHolder = null;

    private void Update() => playerStatsDataHolder.Tick();
}
