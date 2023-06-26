using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Utils.Validator
{
    public interface IValidator
    {
        bool IsCpf(string cpf);
    }
}
