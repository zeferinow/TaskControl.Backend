using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Models
{
    public class JwtLogin
    {
        public string AccessToken { get; set; }
        public string TokenId { get; set; }
    }
}
