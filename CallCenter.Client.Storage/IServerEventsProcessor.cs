namespace CallCenter.Common
{
    public interface IServerEventsProcessor
    {
        IOperatorProcessor OperatorProcessor { get; }
        IChatProcessor ChatProcessor { get; }
    }
}