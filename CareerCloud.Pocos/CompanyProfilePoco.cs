namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        public CompanyProfilePoco()
        {
            //CompanyDescriptions = new HashSet<CompanyDescriptionPoco>();
            //CompanyJobs = new HashSet<CompanyJobPoco>();
            //CompanyLocations = new HashSet<CompanyLocationPoco>();
        }

        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Column("Registration_Date")]
        public DateTime RegistrationDate { get; set; }

        [Column("Company_Website")]
        [StringLength(100)]
        public string CompanyWebsite { get; set; }

        [Column("Contact_Phone")]
        [Required]
        [StringLength(20)]
        public string ContactPhone { get; set; }

        [Column("Contact_Name")]
        [StringLength(50)]
        public string ContactName { get; set; }

        [Column("Company_Logo")]
        public byte[] CompanyLogo { get; set; }

        [Column(name:"Time_Stamp",TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
        
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
    }
}
