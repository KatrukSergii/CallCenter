using System;
using CallCenter.Common;
using CallCenter.Common.Entities;

namespace CallCenterRepository.Controllers
{
    public interface IOperatorsController:IEntityController<IOperator>
    {
        IOperator GetByNumber(string number);

        void LogAction(IOperatorEventInfo eventInfo, DateTime time);
    }
}
