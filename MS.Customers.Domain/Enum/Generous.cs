using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.Enum
{
    [Flags]
    public enum Generous
    {
        [Description("Masculino")]
        Masculine = 0,
        [Description("Feminino")]
        Feminine = 1,
        [Description("Outros")]
        Others = 2
    }
}
