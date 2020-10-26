using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtToken.Model
{
    public class LoginReqeust
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
