namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        public ApplicantProfilePoco()
        {
            Applications = new HashSet<ApplicantJobApplicationPoco>();
            ApplicantEducation = new HashSet<ApplicantEducationPoco>();
            ApplicantResumes = new HashSet<ApplicantResumePoco>();
            ApplicantSkills = new HashSet<ApplicantSkillPoco>();
            ApplicantWorkHistory = new HashSet<ApplicantWorkHistoryPoco>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid Login { get; set; }

        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }

        [StringLength(10)]
        public string Currency { get; set; }

        [Column("Country_Code")]
        [StringLength(10)]
        public string Country { get; set; }

        [Column("State_Province_Code")]
        [StringLength(10)]
        public string Province { get; set; }

        [Column("Street_Address")]
        [StringLength(100)]
        public string Street { get; set; }

        [Column("City_Town")]
        [StringLength(100)]
        public string City { get; set; }

        [Column("Zip_Postal_Code")]
        [StringLength(20)]
        public string PostalCode { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> Applications { get; set; }

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducation { get; set; }

        public virtual SecurityLoginPoco SecurityLogin { get; set; }

        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }

        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }

        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }

        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
    }
}
