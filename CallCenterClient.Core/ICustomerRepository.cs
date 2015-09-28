using CallCenter.Client.Core;
using CallCenter.Client.Storage;

public interface ICustomerRepository
{
    ICustomer GetNexCustomer(IOperator @operator);
    void SaveCustomer(ICustomer ustomer);
    void DeleteCustomerById(int customerId);
}