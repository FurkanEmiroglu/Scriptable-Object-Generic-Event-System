namespace Twenty.SOGameEvents
{
    public interface IEventListener<T>
    {
        void OnEventRaised(T parameter);
    }
}