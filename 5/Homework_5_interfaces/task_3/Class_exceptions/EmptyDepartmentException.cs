using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1.Class_exceptions
{
    class EmptyDerartmentException : ApplicationException
    {
        public EmptyDerartmentException(string message = "Department is empty") : base(message) { }
    }
}