using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.LogicExceptions
{
    public class WrongRoleExceptionMaintenance : Exception
    {
        public WrongRoleExceptionMaintenance(string message,Exception exception):base(message,exception) { }

        public WrongRoleExceptionMaintenance(string message) : base(message) { }

    }

}
