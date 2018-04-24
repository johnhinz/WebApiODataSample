namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }

        [Column("Source_IP")]
        [Required]
        [StringLength(15)]
        public string SourceIP { get; set; }

        [Column("Logon_Date")]
        public DateTime LogonDate { get; set; }

        [Column("Is_Succesful")]
        public bool IsSuccesful { get; set; }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }
    }
}