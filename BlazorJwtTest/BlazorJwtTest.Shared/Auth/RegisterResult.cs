using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJwtTest.Shared.Auth {
    public class RegisterResult {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
