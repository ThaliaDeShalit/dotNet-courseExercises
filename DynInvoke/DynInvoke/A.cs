using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class A
    {
        public string Hello(string s)
        {
            return string.Format("Hello {0}", s);
        }
    }
}
