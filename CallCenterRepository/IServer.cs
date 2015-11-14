namespace CallCenterRepository
{
    public interface IServer
    {
        void Start();
        void Stop();

        IOperatorService OperatorService { get; }
    }
}