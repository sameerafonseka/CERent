using CERent.Core.Lib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Account.Lib.Application.Models
{
    public class UserAuthenticateResult
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; }
    }
}
