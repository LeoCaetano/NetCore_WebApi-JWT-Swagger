using System.ComponentModel.DataAnnotations;

namespace NetCore_WebApi_JWT_Swagger.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public string Regra { get; set; }
    }
}
