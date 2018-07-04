using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeScale.src.model.form
{
    public class UserLoginForm
    {
        public string userId { get; set; }
        public string userPassword { get; set; }
        public string userFirstname { get; set; }
        public string userLastname { get; set; }
        public string status { get; set; }
    }
}
