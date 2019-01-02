using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_projekt
{
    class PluginException : ApplicationException
    {
        public PluginException() : base()
        {

        }
        public PluginException(string mess) : base(mess)
        {

        }
        public PluginException(string mess, Exception exception) : base(mess, exception)
        {

        }
    }
}
