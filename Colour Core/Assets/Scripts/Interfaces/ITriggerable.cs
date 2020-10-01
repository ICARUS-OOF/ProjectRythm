namespace ColourCore.Interfaces
{
    public interface ITriggerable
    {
        bool isTriggered { get; set; }
        void Trigger();
    }
}