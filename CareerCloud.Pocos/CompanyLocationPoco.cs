namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }

        [Column("Country_Code")]
        [Required]
        [StringLength(10)]
        public string CountryCode { get; set; }

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

        [IgnoreDataMember]
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
    }
}
