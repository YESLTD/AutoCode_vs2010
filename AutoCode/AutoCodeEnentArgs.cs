using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode
{
    class AutoCodeEnentArgs:EventArgs
    {
        public PublicProperty pp = null;
        public AutoCodeEnentArgs(PublicProperty p_clsPP)
        {
            pp = p_clsPP;
        }
    }
}
