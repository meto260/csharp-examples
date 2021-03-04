using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJwtTest.Shared.ResponseModels {
    public class WebResponse {
        public WebResponse() {
            Status = true;
        }
        public bool Status { get; set; }

        public string Message { get; set; }

        public void SetException(Exception Exception) {
            Status = false;
            Message = Exception.Message;
        }
    }
}
