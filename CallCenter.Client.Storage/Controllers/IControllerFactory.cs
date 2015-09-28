namespace CallCenter.Common.Controllers
{
    public interface IControllerFactory
    {
        IOperatorsController OperatorsController { get; }
        ICallCenterController CallCenterController { get; }
        ICampaignController CampaignController { get; }
        ICustomerController CustomerController { get; }
}
}