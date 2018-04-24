namespace CareerCloud.Pocos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco 
    {
        public SystemLanguageCodePoco()
        {
            CompanyDescriptions = new HashSet<CompanyDescriptionPoco>();
        }

        [Key]
        [StringLength(10)]
        public string LanguageID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("Native_Name")]
        [Required]
        [StringLength(50)]
        public string NativeName { get; set; }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    }
}
