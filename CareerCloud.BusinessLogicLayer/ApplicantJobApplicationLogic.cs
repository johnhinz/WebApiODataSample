using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        //public override ApplicantJobApplicationPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(a => a.Id == id);
        //}

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            foreach (var poco in pocos)
            {
                if (poco.ApplicationDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(110, $"ApplicationDate for ApplicantJobApplication {poco.Id} is greater than today"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
