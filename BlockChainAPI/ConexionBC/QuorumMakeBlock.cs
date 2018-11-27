using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Infrastructure;

namespace ConexionBC
{
    public class QuorumMakeBlock : GenericRpcRequestResponseHandlerNoParam<string>
    {
        public QuorumMakeBlock(IClient client) : base(client, ApiMethods.quorum_makeBlock.ToString())
        {
        }
    }
}