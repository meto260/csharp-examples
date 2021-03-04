using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJwtTest.Shared.Auth {
    public class LoginResult {
        public string Token { get; set; }
        public UserModel user { get; set; }
    }
}
