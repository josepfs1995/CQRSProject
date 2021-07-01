using System.ComponentModel.DataAnnotations;

namespace ControlaloPE.Application.ViewModels{
    public class LoginUsuarioViewModel{
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class RegistrarUsuarioViewModel{
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string Email { get; set; }
         [Required(ErrorMessage = "Contraseña es requerida")]
        public string Contrasena { get; set; }
    }
}