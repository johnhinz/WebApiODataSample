using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Routing;

namespace CareerCloud.OData.Controllers
{
    public class CompanyController : ODataController
    {
        private readonly CompanyProfileLogic _logic;

        public CompanyController()
        {
            _logic = new CompanyProfileLogic(
                new EFGenericRepository<CompanyProfilePoco>(false));
        }

        [ODataRoute("Company")]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<CompanyProfilePoco>))]
        public IQueryable<CompanyProfilePoco> GetCompanyProfile()
        {
            return _logic.GetAll().AsQueryable();
        }

    }
}
