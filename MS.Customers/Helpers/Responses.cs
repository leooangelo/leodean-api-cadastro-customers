using MS.Customer.Domain.ViewModels;
using System.Collections.Generic;

namespace MS.Customer.API.Helpers
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
            => new ResultViewModel("Ocorreu algum erro interno na aplicação, por favor tente novamente.", false);

        public static ResultViewModel DomainErrorMessage(string message)
            => new ResultViewModel(message, false);

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
            => new ResultViewModel(message, errors, false);

        public static ResultViewModel UnauthorizedErrorMessage()
            => new ResultViewModel("A combinação de login e senha está incorreta!", false);
    }
}
