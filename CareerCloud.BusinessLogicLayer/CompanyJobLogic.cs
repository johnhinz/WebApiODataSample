using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
    {
        public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
        {
        }

        //public override CompanyJobPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(c => c.Id == id);
        //}
    }
}
