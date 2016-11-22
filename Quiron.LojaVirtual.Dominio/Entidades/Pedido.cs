using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Required(ErrorMessage = "Informe o nome do cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "Cep:")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe seu endereço")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Display(Name ="Complemento")]
        public string Complemento { get; set; }
        
        [Required(ErrorMessage = "Informe uma cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe um e-mail")]
        public string Email { get; set; }

        [Display(Name = "Embrulha para presente?")]
        public bool EmbrulhaParaPresente { get; set; }

    }
}
