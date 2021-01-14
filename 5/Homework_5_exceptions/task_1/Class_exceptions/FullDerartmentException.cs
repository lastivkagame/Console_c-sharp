using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1.Class_exceptions
{
    class FullDerartmentException : ApplicationException
    {
        public FullDerartmentException(string message = "Department is full") : base(message) { }
    }
}