using MS.Customer.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace MS.Customer.Domain.ViewModel
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O sobrenome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O sobrenome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O sobrenome deve ter no máximo 100 caracteres.")]
        public string LastName { get; set; }

        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve ter no máximo 15 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O telefone não pode ser vazia.")]
        [MinLength(10, ErrorMessage = "O telefone eve ter no mínimo 10 caracteres.")]
        [MaxLength(11, ErrorMessage = "O telefone ter no máximo 11 caracteres.")]
        public string Phone { get; set; }

        [MinLength(11, ErrorMessage = "O CPF deve ter no mínimo 11 caracteres.")]
        [MaxLength(20, ErrorMessage = "O CPF ter no máximo 20 caracteres.")]
        [RegularExpression("^[0-9]*$")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O genero não pode ser vazio.")]
        public Generous Generous { get;  set; }

    }
}
