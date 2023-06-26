using MS.Customer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.ViewModel
{
    public class CustomerUpdateViewModel
    {

        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "O sobrenome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O sobrenome deve ter no máximo 100 caracteres.")]
        public string LastName { get; set; }

        [MinLength(10, ErrorMessage = "O telefone eve ter no mínimo 10 caracteres.")]
        [MaxLength(11, ErrorMessage = "O telefone ter no máximo 11 caracteres.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O genero não pode ser vazio.")]
        public Generous Generous { get; set; }

    }
}
