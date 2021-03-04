using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJwtTest.Shared.Auth {
    public class LoginModel {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginUserTypes LoginUserType { get; set; }
    }

    public enum LoginUserTypes {
        Admin,
        CustomerRepresentative,
        Customer,
        Tenant
    }
}
