using CallCenter.Common.Entities;

namespace CallCenter.Common.Controllers
{
    public interface IOperatorsController:IEntityController<IOperator>
    {
        IOperator GetByNumber(string number);
    }
}
