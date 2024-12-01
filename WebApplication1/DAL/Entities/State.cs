using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado")]// para identificarlo mas facil
        [MaxLength(50, ErrorMessage = "El campo debe tener como mazimo 50 caracteres")]//maximo longitud
        [Required(ErrorMessage = "El campo {0} es obligstorio")]
        public string Name { get; set; }



        [Display(Name = "Pais")]
        //asi se relacionan 2 tablas
        public Country? Country { get; set; }

        [Display(Name = "Id Pais")]
        //Fk
        public Guid CountryId { get; set; }
    }
}
 