using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Services.JwtServices;

public class JwtError
{
    public JwtError(long code, string message)
    {
        Code = code;
        Message = message;
    }

    public long Code { get; set; }
    public string Message { get; set; }
}
