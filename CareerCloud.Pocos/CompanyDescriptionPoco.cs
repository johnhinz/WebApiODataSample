namespace CareerCloud.Pocos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }

        [Required]
        [StringLength(10)]
        public string LanguageId { get; set; }

        [Column("Company_Name")]
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [Column(name: "Company_Description")]
        [StringLength(1000)]
        public string CompanyDescription { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [IgnoreDataMember]
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }

        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }
    }
}
