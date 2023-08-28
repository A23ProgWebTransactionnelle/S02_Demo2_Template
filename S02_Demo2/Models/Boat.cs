using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace S02_Demo2.Models
{
    public class Boat
    {
        public int Id { get; set; }

        [StringLength(64, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string? Description { get; set; }

        [DisplayName("La longueur du bateau en mètres")]
        [Range(3, 500, ErrorMessage ="{0} doit être entre {1} et {2}")]
        public int Length { get; set; }

    }
}
