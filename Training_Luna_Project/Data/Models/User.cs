using System.ComponentModel.DataAnnotations;

namespace Training_Luna_Project.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Kullanıcı Adı en az 3 en fazla 50 karakter aralığında olmalı")]
        public string UserName { get; set; }

        [StringLength(50, MinimumLength = 7)]
        public string Password { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }

        public List<FormModel> FormModels { get; set; }
    }
}