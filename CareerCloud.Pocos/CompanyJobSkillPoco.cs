namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Job { get; set; }

        [Required]
        [StringLength(100)]
        public string Skill { get; set; }

        [Column("Skill_Level")]
        [Required]
        [StringLength(10)]
        public string SkillLevel { get; set; }

        public int Importance { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
