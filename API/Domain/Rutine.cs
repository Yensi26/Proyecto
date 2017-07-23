using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain
{
    public class Rutine
    {
        [Key]
        public int RutineId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(40, ErrorMessage = "The maximun length for field {0} us {1} characters.")]
        [Display(Name = "Rutine Name")]
        [Index("User_Rutine_Index", IsUnique = true)]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [JsonIgnore]
        public virtual ICollection<Excercise> Excercises { get; set; }
    }
}
