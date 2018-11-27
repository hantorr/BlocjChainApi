using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Infrastructure;

namespace ConexionBC
{
    public class QuorumNodeInfo : GenericRpcRequestResponseHandlerNoParam<NodeInfo>
    {
        public QuorumNodeInfo(IClient client) : base(client, ApiMethods.quorum_nodeInfo.ToString())
        {
        }
    }
}