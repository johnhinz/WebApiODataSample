namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        [Required]
        public string Resume { get; set; }

        [Column("Last_Updated")]
        public DateTime? LastUpdated { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
