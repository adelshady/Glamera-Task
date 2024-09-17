using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.Common.Exception
{
    public class CustomException : System.Exception
    {
      
        public CustomException(string message, System.Exception innerException = null)
            : base(message, innerException)
        {
        }

    }
}
