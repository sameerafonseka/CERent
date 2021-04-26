using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Core.Lib.QueueModels
{
    public class LoginNotification : ILoginNotification
    {
        public string Email { get; set; }
    }
}
