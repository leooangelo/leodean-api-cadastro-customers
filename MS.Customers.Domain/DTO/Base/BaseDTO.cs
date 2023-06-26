using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.DTO.Base
{
    public abstract class BaseDTO
    {
        [JsonProperty(Order = 1)]
        public Guid? Uid { get; set; }
    }
}
