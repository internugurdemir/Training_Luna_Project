using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_Luna_Project.Data.Models
{
    public class FormModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Field> Fields { get; set; }
    }

}
