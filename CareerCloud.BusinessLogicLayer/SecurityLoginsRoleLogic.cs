using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
        {
        }

        //public override SecurityLoginsRolePoco Get(Guid id)
        //{
        //    return _repository.GetSingle(s => s.Id == id);
        //}
    }
}
