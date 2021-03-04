using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJwtTest.Shared.ResponseModels {
    public class ServiceResponse<T> : WebResponse {
        public T Data { get; set; }
    }
}
