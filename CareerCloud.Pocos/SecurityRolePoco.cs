namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        public SecurityRolePoco()
        {
            SecurityLoginsRoles = new HashSet<SecurityLoginsRolePoco>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }

        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}
