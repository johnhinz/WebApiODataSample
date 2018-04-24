using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco 
    {
        public SystemCountryCodePoco()
        {
            ApplicantProfiles = new HashSet<ApplicantProfilePoco>();
            ApplicantWorkHistory = new HashSet<ApplicantWorkHistoryPoco>();
        }

        [Key]
        [StringLength(10)]
        [DataMember]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }

        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
    }
}
