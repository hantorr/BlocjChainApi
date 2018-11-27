using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.RPC.TransactionReceipts;


namespace ConexionBC
{
    public class QuorumPrivateContractTests
    {
        public async Task<int> ShouldBeAbleToConnectTo7NodesPrivate()
        {
            var ipAddress = DefaultSettings.QuorumIPAddress;
            var node1Port = "30303";
            var urlNode1 = ipAddress + ":" + node1Port;

            var address = "0x274ab43196161928d04143cb6ee56429bbc38da1";
            var abi = "[{'constant':true,'inputs':[],'name':'totalSupply','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'issuers','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'accounts','outputs':[{'name':'bankAccount','type':'bytes12'},{'name':'id','type':'address'},{'name':'bankId','type':'address'},{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'banks','outputs':[{'name':'id','type':'address'},{'name':'name','type':'bytes32'},{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'inputs':[],'payable':false,'stateMutability':'nonpayable','type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_issuer','type':'address'},{'indexed':true,'name':'_bank','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'},{'indexed':false,'name':'_totalSupply','type':'uint256'}],'name':'Issued','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_id','type':'address'},{'indexed':false,'name':'_name','type':'string'}],'name':'BankCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'_bankAddress','type':'address'},{'indexed':false,'name':'_accountAddress','type':'address'}],'name':'AccountCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_bankAddress','type':'address'},{'indexed':true,'name':'_accountAddress','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'CashedIn','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_accountAddress','type':'address'},{'indexed':true,'name':'_bankAddress','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'CashedOut','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'Transfered','type':'event'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'isIssuer','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_amount','type':'uint256'},{'name':'_bank_address','type':'address'}],'name':'issue','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_bankAddress','type':'address'},{'name':'_bankName','type':'string'}],'name':'createBank','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'getBank','outputs':[{'name':'','type':'address'},{'name':'','type':'string'},{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_bank_address','type':'address'}],'name':'getBankBalance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_accountAddress','type':'address'},{'name':'_bankAccount','type':'string'}],'name':'createAccount','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'getAccount','outputs':[{'name':'','type':'address'},{'name':'','type':'uint256'},{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_bankAccount','type':'string'}],'name':'getAddressOfBankAccount','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_accountAddress','type':'address'}],'name':'getAccountBalance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_accountAddress','type':'address'},{'name':'_amount','type':'uint256'}],'name':'cashIn','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_amount','type':'uint256'}],'name':'cashOut','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_to','type':'string'},{'name':'_amount','type':'uint256'}],'name':'transfer','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'}]";
           

            var web3Node1 = new ConexionBC(urlNode1);
            var transactionService = new TransactionReceiptPollingService(web3Node1.TransactionManager);
            var account = await web3Node1.Eth.CoinBase.SendRequestAsync();
            var contract = web3Node1.Eth.GetContract(abi, address);
            var functionSet = contract.GetFunction("accounts");

            //set the private for
            var privateFor = new List<string>(new[] { "0x88f4549c58d5dc8a8374272a999222a639daa149" });
            web3Node1.SetPrivateRequestParameters(privateFor);
            //send transaction
            var txnHash = await transactionService.SendRequestAndWaitForReceiptAsync(() => functionSet.SendTransactionAsync(account, 0));

            var node1Value = await GetValue(abi, address, urlNode1);
           

            txnHash = await transactionService.SendRequestAndWaitForReceiptAsync(() => functionSet.SendTransactionAsync(account, 42));

            //node1
            return node1Value = await GetValue(abi, address, urlNode1);

            //private.set(4,{from:eth.coinbase,privateFor:["ROAZBWtSacxXQrOe3FGAqJDyJjFePR5ce4TSIzmJ0Bc="]});
        }

        private static async Task<int> GetValue(string abi, string address, string nodeUrl)
        {
            //normal geth is ok
            var web3 = new Web3.Web3(nodeUrl);
            var contract = web3.Eth.GetContract(abi, address);
            var functionGet = contract.GetFunction("get");
            return await functionGet.CallAsync<int>();
        }
    }
}
