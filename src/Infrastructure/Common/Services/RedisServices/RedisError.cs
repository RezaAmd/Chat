using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Common.Services.RedisServices;

public class RedisError
{
    public RedisError(long code, string message)
    {
        Code = code;
        Message = message;
    }

    public long Code { get; set; }
    public string Message { get; set; }
}
