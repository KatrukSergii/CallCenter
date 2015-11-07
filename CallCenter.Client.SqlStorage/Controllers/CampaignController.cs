using CallCenter.Common.Entities;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class CampaignController : EntityControllerBase<ICampaign>
    {
        public CampaignController(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override string ColumnNameToSearch
        {
            get
            {
                return "Name";
            }
        }
    }
}