using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ServicesResponse<TargetObject>
    {
        public bool Status { set; get; }
        public string Message { set; get; }
        public TargetObject AttachedObject { set; get; }
    }
}
