using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingOrg.Application.Exceptions
{
    public class CameramanNotFoundException : Exception

    {
        public CameramanNotFoundException(string? message) : base(message)
        {

        }
    }
}
