namespace ColourCore
{
    namespace Interfaces
    {
        public interface ITriggerable
        {
            bool isTriggered { get; set; }
            void Trigger();
        }
    }
}