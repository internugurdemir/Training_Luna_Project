using System.ComponentModel.DataAnnotations;

namespace Training_Luna_Project.Data.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Required { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DataType { get; set; }
        public List<FormModel> FormModels { get; set; }

    }
}
