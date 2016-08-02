namespace CallCenter.Common
{
    public interface IServer
    {
        void Start();
        void Stop();

        IOperatorService OperatorService { get; }
    }
}