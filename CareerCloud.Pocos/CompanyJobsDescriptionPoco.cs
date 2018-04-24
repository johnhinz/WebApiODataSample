namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Job { get; set; }

        [Column("Job_Name")]
        [StringLength(100)]
        public string JobName { get; set; }

        [Column("Job_Descriptions")]
        [StringLength(1000)]
        public string JobDescriptions { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}
