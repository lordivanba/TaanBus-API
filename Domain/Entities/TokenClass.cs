using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taanbus.Domain.Entities
{
    public class TokenClass
    {
        public string TokenOrMessage { get; set; } = "";
        public int Success { get; set; } = 0;
    }
}