﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class B
    {
        public string Hello(string s)
        {
            return string.Format("Bonjour {0}", s);
        }
    }
}
