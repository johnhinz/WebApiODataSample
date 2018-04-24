namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Applicant { get; set; }
        [Required]
        [StringLength(100)]
        public string Skill { get; set; }

        [Column("Skill_Level")]
        [Required]
        [StringLength(50)]
        public string SkillLevel { get; set; }

        [Column("Start_Month")]
        public byte StartMonth { get; set; }

        [Column("Start_Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        public byte EndMonth { get; set; }

        [Column("End_Year")]
        public int EndYear { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
