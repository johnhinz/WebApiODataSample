using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }
        public override CompanyDescriptionPoco Get(Guid id)
        {
            return _repository.GetSingle(c => c.Id == id);
        }

        //public override void Add(CompanyDescriptionPoco[] pocos)
        //{
        //    Verify(pocos);
        //    base.Add(pocos);
        //}

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (!string.IsNullOrEmpty(poco.CompanyDescription))
                {
                    if (poco.CompanyDescription.Length < 3)
                    {
                        exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription {poco.Id} is less than 3 characters"));
                    }
                }
                else
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription {poco.Id} is null"));
                }

                if (!string.IsNullOrEmpty(poco.CompanyName))
                {
                    if (poco.CompanyName.Length < 3)
                    {
                        exceptions.Add(new ValidationException(106, $"CompanyName for CompanyDescription {poco.Id} is less than 3 characters"));
                    }
                }
                else
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName for CompanyDescription {poco.Id} is null"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
