using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandOutlet.Models
{
    public class LoginModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }      
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }

        public long? UserRoleId { get; set; }


    }
}