using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        //public override ApplicantSkillPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(a => a.Id == id);
        //}

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }


        protected override void Verify(ApplicantSkillPoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (ApplicantSkillPoco poco in pocos)
            {
                if (poco.StartMonth > 12)
                {
                    exceptions.Add(new ValidationException(101,$"ApplicantSkill {poco.Id} has an invalid StartMonth {poco.StartMonth}"));
                }
                if (poco.EndMonth > 12)
                {
                    exceptions.Add(new ValidationException(102, $"ApplicantSkill {poco.Id} has an invalid EndMonth {poco.EndMonth}"));
                }
                if (poco.StartYear < 1900 || poco.StartYear > DateTime.Now.Year)
                {
                    exceptions.Add(new ValidationException(103, $"ApplicantSkill {poco.Id} has an invalid StartYear {poco.StartYear}"));
                }
                if (poco.EndYear < poco.StartYear)
                {
                    exceptions.Add(new ValidationException(104, $"ApplicantSkill {poco.Id} has an invalid EndYear {poco.EndYear}"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
