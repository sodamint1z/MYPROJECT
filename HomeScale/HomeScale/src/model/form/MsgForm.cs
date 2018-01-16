using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeScale.src.model.form
{
    public class MsgForm
    {
        public static int STATUS_SUCCESS = 1;
        public static int STATUS_ERROR = 0;

        public int statusFlag { get; set; }
        public string messageDescription { get; set; }
    }
}
