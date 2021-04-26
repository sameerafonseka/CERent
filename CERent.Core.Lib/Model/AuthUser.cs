using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Core.Lib.Model
{
    public class AuthUser
    {
        public string Email { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        public UserType UserType { get; set; }
    }
}
