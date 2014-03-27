using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genome
{
    public class UserContext
    {
        internal string Cookie { get; private set; }
        public UserContext(string context)
        {
            Cookie = context;
        }

        public override string ToString()
        {
            return Cookie;
        }
    }
}
