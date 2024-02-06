using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Users
{
    public class CreateUserView
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
