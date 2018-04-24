using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            _logic = new CompanyProfileLogic(
                new EFGenericRepository<CompanyProfilePoco>(false));
        }

        [HttpGet]
        [Route("profile/{companyProfileId}")]
        [ResponseType(typeof(CompanyProfilePoco))]
        public IHttpActionResult GetCompanyProfile(Guid companyProfileId)
        {
            CompanyProfilePoco poco = _logic.Get(companyProfileId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]
        public IHttpActionResult GetAllcompanyProfile()
        {
            List<CompanyProfilePoco> pocos = _logic.GetAll();
            return Ok(pocos);
        }


        [HttpGet]
        [Route("profile/id")]
        [ResponseType(typeof(List<Guid>))]
        public IHttpActionResult GetAllcompanyProfileIds()
        {
            List<CompanyProfilePoco> pocos = _logic.GetAll();

            return Ok(pocos.Select(p => new { p.Id }));
        }

        [HttpPost]
        [Route("profile")]
        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }


    }
}
