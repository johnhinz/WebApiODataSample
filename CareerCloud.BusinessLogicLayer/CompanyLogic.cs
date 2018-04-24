using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLogic
    {
        private IDataRepository<CompanyDescriptionPoco> _descRepo;
        private IDataRepository<CompanyProfilePoco> _compRepo;

        public CompanyDescriptionPoco[] GetCompanyByName(string name)
        {
            _descRepo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            //IEnumerable<Guid> descs = _descRepo.GetList(d => d.CompanyName.Contains(name)).Select(c => c.Company);
            //_compRepo = new EFGenericRepository<CompanyProfilePoco>(false);
            //return _compRepo.GetList(c => descs.Contains(c.Id), c => c.CompanyDescriptions).ToArray();

            return _descRepo.GetList(d => d.CompanyName.Contains(name)).ToArray();


        }

    }
}
