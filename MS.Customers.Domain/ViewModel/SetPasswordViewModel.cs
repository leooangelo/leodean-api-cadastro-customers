using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.ViewModel
{
    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve ter no máximo 15 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha não pode ser vazia.")]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve ter no máximo 15 caracteres.")]
        public string ConfirmPassword { get; set; }
    }
}
