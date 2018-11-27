using Nethereum.JsonRpc.Client;
using Nethereum.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBC
{
    public class QuorumChainService: RpcClientWrapper
    {
        public QuorumChainService(IClient client) : base(client)
        {
            CanonicalHash = new QuorumCanonicalHash(client);
            IsBlockMaker = new QuorumIsBlockMaker(client);
            IsVoter = new QuorumIsVoter(client);
            MakeBlock = new QuorumMakeBlock(client);
            PauseBlockMaker = new QuorumPauseBlockMaker(client);
            ResumeBlockMaker = new QuorumResumeBlockMaker(client);
            Vote = new QuorumVote(client);
            NodeInfo = new QuorumNodeInfo(client);
        }

        public QuorumCanonicalHash CanonicalHash { get; private set; }
        public QuorumIsBlockMaker IsBlockMaker { get; private set; }
        public QuorumIsVoter IsVoter { get; private set; }
        public QuorumMakeBlock MakeBlock { get; private set; }
        public QuorumPauseBlockMaker PauseBlockMaker { get; private set; }
        public QuorumResumeBlockMaker ResumeBlockMaker { get; private set; }
        public QuorumVote Vote { get; private set; }
        public QuorumNodeInfo NodeInfo { get; private set; }
    }
}
