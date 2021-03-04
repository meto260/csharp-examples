using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJwtTest.Shared.Auth {
    public class UserModel {
        public string userid { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public string fullname { get; set; }
    }
}
