using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.ViewModel
{
    public class CustomerUpdatePasswordViewModel
    {
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve ter no máximo 15 caracteres.")]
        public string NewPassword { get; set; }
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve ter no máximo 15 caracteres.")]
        public string OldPassword { get; set; }
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve ter no máximo 15 caracteres.")]
        public string NewPasswordConfirmed { get; set; }
    }
}
