using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Models
{
    public class AddUser
    {
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
    }
}
