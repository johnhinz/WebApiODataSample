using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        //public override ApplicantEducationPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(a => a.Id == id);
        //}

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (ApplicantEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation Id {poco.Id} is less than three characters."));
                } else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation Id {poco.Id} is less than three characters."));
                }
                if (poco.StartDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, $"StartDate for ApplicantEducation Id {poco.Id} in the future."));
                }
                if (poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109, $"StartDate for ApplicantEducation Id {poco.Id} in the future."));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
            
        }
    }
}
