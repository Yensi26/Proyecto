using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain
{
    public class Excercise
    {
        [Key]
        public int ExcerciseId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(40, ErrorMessage = "The maximun length for field {0} us {1} characters.")]
        [Display(Name = "Excercise Name")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        public int RutineId { get; set; }

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int Rest { get; set; }

        [JsonIgnore]
        public virtual Rutine Rutine { get; set; }
    }
}
