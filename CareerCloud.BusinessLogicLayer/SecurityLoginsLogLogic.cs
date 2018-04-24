using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsLogLogic : BaseLogic<SecurityLoginsLogPoco>
    {
        public SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : base(repository)
        {
        }

        //public override SecurityLoginsLogPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(s => s.Id == id);
        //}
    }
}
