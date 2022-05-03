using System;
using System.Collections.Generic;

#nullable disable

namespace Common
{
    public partial class Response
    {
        public Response()
        {
            this.Status = true;
            this.Message = string.Empty;
            this.Data = null;
        }
        public bool Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
