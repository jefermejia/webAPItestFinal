using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; }// PK primary key de cada tabla 
        public virtual DateTime? CreateDate { get; set; } 
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
