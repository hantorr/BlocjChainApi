using Nethereum.JsonRpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBC
{
    public class RpcResponseException : Exception
    {
        public RpcResponseException(RpcError rpcError) : base(rpcError.Message)
        {
            RpcError = rpcError;
        }

        public RpcError RpcError { get; }
    }

    public class RpcResponseFormatException : Exception
    {
        public RpcResponseFormatException(string message, FormatException innerException)
            : base(message, innerException)
        {
        }
    }
}
