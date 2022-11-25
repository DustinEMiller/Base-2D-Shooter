using UnityEngine;

public class StatModifier
{
    [SerializeField] private float value = 0f;
    [SerializeField] private StatModifierType type = StatModifierType.None;

    public float Value { get { return value; } }
    public StatModifierType Type { get { return type; } }

    public StatModifier(float value, StatModifierType type)
    {
        this.value = value;
        this.type = type;
    }
}
