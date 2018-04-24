using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        //public override CompanyJobEducationPoco Get(Guid id)
        //{
        //    return _repository.GetSingle(c => c.Id == id);
        //}

        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(200, $"Major in CompanyJobEducation {poco.Id} cannot be less than two characters"));
                }
                else if (poco.Major.Length < 2)
                {
                    exceptions.Add(new ValidationException(200, $"Major in CompanyJobEducation {poco.Id} cannot be less than two characters"));
                }

                if (poco.Importance < 0)
                {
                    exceptions.Add(new ValidationException(201, $"Importance on CompanyJobEducation {poco.Id} cannot be negative."));
                }
            }


            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
