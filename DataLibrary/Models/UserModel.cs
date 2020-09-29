using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserModel
    {
        public string EmailAddress { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }
    }
}
