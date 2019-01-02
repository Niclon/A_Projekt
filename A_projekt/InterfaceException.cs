using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_projekt
{
    class InterfaceException : Exception
    {
        public InterfaceException() : base()
        {

        }
        public InterfaceException(string mess) : base(mess)
        {

        }
        public InterfaceException(string mess, Exception exception) : base(mess, exception)
        {

        }
    }
}
