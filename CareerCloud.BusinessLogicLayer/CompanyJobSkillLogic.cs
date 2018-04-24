using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
    {
        public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        //public override CompanyJobSkillPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(c => c.Id == id);
        //}

        public override void Update(CompanyJobSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyJobSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (poco.Importance < 0)
                {
                    exceptions.Add(new ValidationException(400, $"Importance for CompanyJobSkill {poco.Id} cannot be less than zero"));
                }
            }
            if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
