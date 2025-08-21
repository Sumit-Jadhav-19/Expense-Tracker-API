using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Domain.Entities
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class TokenModel
    {
        public string RefreshToken { get; set; }
    }
}
