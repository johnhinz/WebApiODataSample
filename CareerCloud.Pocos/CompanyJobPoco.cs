namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        public CompanyJobPoco()
        {
            ApplicantJobApplications = new HashSet<ApplicantJobApplicationPoco>();
            CompanyJobEducations = new HashSet<CompanyJobEducationPoco>();
            CompanyJobsDescriptions = new HashSet<CompanyJobDescriptionPoco>();
        }

        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        public Guid Company { get; set; }

        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        public bool IsCompanyHidden { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }

        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }

        [IgnoreDataMember]
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }

        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobsDescriptions { get; set; }
    }
}
