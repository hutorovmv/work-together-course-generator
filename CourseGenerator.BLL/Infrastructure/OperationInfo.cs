using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.BLL.Infrastructure
{
    public class OperationInfo
    {
        public bool Succeeded { get; }
        public string Message { get; }
        public string Property { get; }

        public OperationInfo(bool succeeded, string message, string property = "")
        {
            Succeeded = succeeded;
            Message = message;
            Property = property;
        }
    }
}
