using System.ComponentModel.DataAnnotations;

namespace NetCore_WebApi_JWT_Swagger.Entidades
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Marca deve ter o tamanho entre 3 e 20 caracteres")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Marca é Obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Marca deve ter o tamanho entre 3 e 20 caracteres")]
        [Display(Name = "Marca do Produto")]
        public string Marca { get; set; }
    }
}
