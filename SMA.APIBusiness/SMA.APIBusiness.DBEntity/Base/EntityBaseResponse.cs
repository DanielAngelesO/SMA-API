using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBaseResponse
    {
        public bool Issuccess { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }



    }
}
