using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    [Serializable]
    public class Client
    {
        public int ClientId { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{6,15}$", ErrorMessage ="Some characters are not allowed")]
        public string Login { get; set; }

        [RegularExpression(@"(?=.*?[0-9]).{6,15}$", ErrorMessage = ("Some characters are not allowed"))]
        public string Password { get; set; }
        public bool State { get; set; }

        public Client()
        {

        }
        public Client(string login, string password)
        {
            Login = login;
            Password = password;
            State = true;
        }

    }
}
