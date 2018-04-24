using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq;
using System.Collections.Generic;
using System;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {

        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }
        //public override CompanyProfilePoco Get(Guid id)
        //{
        //    return _repository.GetSingle(c => c.Id == id);
        //}

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override List<CompanyProfilePoco> GetAll()
        {
            List<CompanyProfilePoco> pocos = _repository.GetAll(p => p.CompanyDescriptions, p => p.CompanyJobs, p => p.CompanyLocations).ToList();
            return pocos;
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            string[] acceptedDomains = new string[] { ".ca", ".com", ".biz" };

            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.Id} is not a valid doamin."));
                } else if (!acceptedDomains.Any(t => t == poco.CompanyWebsite.Substring(poco.CompanyWebsite.Length - t.Length)))
                {
                    exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.Id} is not a valid doamin."));
                }

                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is required"));
                }
                else 
                {
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length < 3)
                    {
                        exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                    } else
                    {
                        if (phoneComponents[0].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[1].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[2].Length < 4)
                        {
                            exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                        }
                    }

                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
