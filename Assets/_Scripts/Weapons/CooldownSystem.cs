
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

public class CooldownSystem : MonoBehaviour
{
    private readonly List<CooldownData> cooldowns = new List<CooldownData>();

    private void Update()
    {
        ProcessCooldowns();
    }

    public void PutOnCoolDown(IHasCoolDown coolDown)
    {
        cooldowns.Add(new CooldownData(coolDown));
    }

    public bool IsOnCoolDown(int id)
    {
        foreach (CooldownData cooldown in cooldowns)
        {
            if (cooldown.Id == id)
            {
                return true;
            }
        }

        return false;
    }

    public float GetRemaingDuration(int id)
    {
        foreach (CooldownData cooldown in cooldowns)
        {
            if (cooldown.Id != id)
            {
                continue;
            }

            return cooldown.RemainingTime;
        }

        return 0f;
    }

    private void ProcessCooldowns()
    {
        float deltaTime = Time.deltaTime;

        for (int i = cooldowns.Count - 1; i >= 0; i--)
        {
            if (cooldowns[i].DecrementCooldown(deltaTime))
            {
                cooldowns.RemoveAt(i);
            }
        }
    }
}

public class CooldownData
{
    public int Id { get; }
    public float RemainingTime { get; private set; }
    
    public CooldownData(IHasCoolDown coolDown)
    {
        Id = coolDown.Id;
        RemainingTime = coolDown.CoolDownDuration;
    }

    public bool DecrementCooldown(float deltaTime)
    {
        RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);

        return RemainingTime == 0;
    }

    
}
