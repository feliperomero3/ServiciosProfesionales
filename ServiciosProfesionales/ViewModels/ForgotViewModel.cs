using System.ComponentModel.DataAnnotations;

namespace ServiciosProfesionales.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}