using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Account.Lib.Application.Models
{
    public class LoginResult
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public bool IsValidUser { get; set; }

        public string Token { get; set; }
    }
}
