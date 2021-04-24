using CERent.Core.Lib.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Account.Lib.Domain.Models
{
    public class User : BaseDomainModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; }

        public string Password { get; set; }

    }
}
