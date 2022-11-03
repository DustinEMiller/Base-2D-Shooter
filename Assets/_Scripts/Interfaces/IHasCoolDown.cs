namespace _Scripts.Interfaces
{
    public interface IHasCoolDown
    {
        int Id { get; }
        float CoolDownDuration { get; }
    }
}