using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Dtos.Account
{
    public class NewUserDto
    {
        public string?  userName { get; set; }
        public string?  Email { get; set; }
        public string?  token { get; set; }

    }
}