using CallCenter.Common.Entities;

namespace CallCenter.Common
{
    public interface IOperatorProcessor
    {
        IOperator ChangeOperatorState(IOperatorEventInfo eventInfo);
    }
}
