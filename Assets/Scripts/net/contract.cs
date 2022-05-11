﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace impact
{


    public class ImpactConsole
    {
        public static async Task Main()
        {
            var url = "http://testchain.nethereum.com:8545";
            //var url = "https://mainnet.infura.io";
            var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            var web3 = new Web3(account, url);
            var contractAddress = "";
            
             /* Deployment 
            var impactDeployment = new ImpactDeployment();

            var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<ImpactDeployment>().SendRequestAndWaitForReceiptAsync(impactDeployment);
            var contractAddress = transactionReceiptDeployment.ContractAddress;
             */ 
            var contractHandler = web3.Eth.GetContractHandler(contractAddress);

            /** Function: addScore**/
            /*
            var addScoreFunction = new AddScoreFunction();
            addScoreFunction.User = user;
            addScoreFunction.Score = score;
            var addScoreFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(addScoreFunction);
            */


            /** Function: approve**/
            /*
            var approveFunction = new ApproveFunction();
            approveFunction.To = to;
            approveFunction.TokenId = tokenId;
            var approveFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(approveFunction);
            */


            /** Function: balanceOf**/
            /*
            var balanceOfFunction = new BalanceOfFunction();
            balanceOfFunction.Owner = owner;
            var balanceOfFunctionReturn = await contractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
            */


            /** Function: baseTokenURI**/
            /*
            var baseTokenURIFunctionReturn = await contractHandler.QueryAsync<BaseTokenURIFunction, string>();
            */


            /** Function: getApproved**/
            /*
            var getApprovedFunction = new GetApprovedFunction();
            getApprovedFunction.TokenId = tokenId;
            var getApprovedFunctionReturn = await contractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction);
            */


            /** Function: isApprovedForAll**/
            /*
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
            isApprovedForAllFunction.Owner = owner;
            isApprovedForAllFunction.Operator = @operator;
            var isApprovedForAllFunctionReturn = await contractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction);
            */


            /** Function: leaderboard**/
            /*
            var leaderboardFunction = new LeaderboardFunction(); 
            leaderboardFunction.ReturnValue1 = returnValue1;
            var leaderboardOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<LeaderboardFunction, LeaderboardOutputDTO>(leaderboardFunction);
            */


            /** Function: mint**/
            /*
            var mintFunction = new MintFunction();
            mintFunction.Id = id;
            var mintFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(mintFunction);
            */


            /** Function: name**/
            /*
            var nameFunctionReturn = await contractHandler.QueryAsync<NameFunction, string>();
            */


            /** Function: owner**/
            /*
            var ownerFunctionReturn = await contractHandler.QueryAsync<OwnerFunction, string>();
            */


            /** Function: ownerOf**/
            /*
            var ownerOfFunction = new OwnerOfFunction();
            ownerOfFunction.TokenId = tokenId;
            var ownerOfFunctionReturn = await contractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction);
            */


            /** Function: renounceOwnership**/
            /*
            var renounceOwnershipFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>();
            */


            /** Function: safeTransferFrom**/
            /*
            var safeTransferFromFunction = new SafeTransferFromFunction();
            safeTransferFromFunction.From = from;
            safeTransferFromFunction.To = to;
            safeTransferFromFunction.TokenId = tokenId;
            var safeTransferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction);
            */


            /** Function: safeTransferFrom**/
            /*
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
            safeTransferFrom1Function.From = from;
            safeTransferFrom1Function.To = to;
            safeTransferFrom1Function.TokenId = tokenId;
            safeTransferFrom1Function.Data = data;
            var safeTransferFrom1FunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function);
            */


            /** Function: setApprovalForAll**/
            /*
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
            setApprovalForAllFunction.Operator = @operator;
            setApprovalForAllFunction.Approved = approved;
            var setApprovalForAllFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction);
            */


            /** Function: setBaseTokenURI**/
            /*
            var setBaseTokenURIFunction = new SetBaseTokenURIFunction();
            setBaseTokenURIFunction.Uri = uri;
            var setBaseTokenURIFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setBaseTokenURIFunction);
            */


            /** Function: supportsInterface**/
            /*
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
            supportsInterfaceFunction.InterfaceId = interfaceId;
            var supportsInterfaceFunctionReturn = await contractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction);
            */


            /** Function: symbol**/
            /*
            var symbolFunctionReturn = await contractHandler.QueryAsync<SymbolFunction, string>();
            */


            /** Function: tokenURI**/
            /*
            var tokenURIFunction = new TokenURIFunction();
            tokenURIFunction.TokenId = tokenId;
            var tokenURIFunctionReturn = await contractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction);
            */


            /** Function: transferFrom**/
            /*
            var transferFromFunction = new TransferFromFunction();
            transferFromFunction.From = from;
            transferFromFunction.To = to;
            transferFromFunction.TokenId = tokenId;
            var transferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction);
            */


            /** Function: transferOwnership**/
            /*
            var transferOwnershipFunction = new TransferOwnershipFunction();
            transferOwnershipFunction.NewOwner = newOwner;
            var transferOwnershipFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction);
            */
        }

    }

    public partial class ImpactDeployment : ImpactDeploymentBase
    {
        public ImpactDeployment() : base(BYTECODE) { }
        public ImpactDeployment(string byteCode) : base(byteCode) { }
    }

    public class ImpactDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ImpactDeploymentBase() : base(BYTECODE) { }
        public ImpactDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddScoreFunction : AddScoreFunctionBase { }

    [Function("addScore", "bool")]
    public class AddScoreFunctionBase : FunctionMessage
    {
        [Parameter("string", "user", 1)]
        public virtual string User { get; set; }
        [Parameter("uint256", "score", 2)]
        public virtual BigInteger Score { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class BaseTokenURIFunction : BaseTokenURIFunctionBase { }

    [Function("baseTokenURI", "string")]
    public class BaseTokenURIFunctionBase : FunctionMessage
    {

    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class LeaderboardFunction : LeaderboardFunctionBase { }

    [Function("leaderboard", typeof(LeaderboardOutputDTO))]
    public class LeaderboardFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "_data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SetBaseTokenURIFunction : SetBaseTokenURIFunctionBase { }

    [Function("setBaseTokenURI")]
    public class SetBaseTokenURIFunctionBase : FunctionMessage
    {
        [Parameter("string", "uri", 1)]
        public virtual string Uri { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }





    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BaseTokenURIOutputDTO : BaseTokenURIOutputDTOBase { }

    [FunctionOutput]
    public class BaseTokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class LeaderboardOutputDTO : LeaderboardOutputDTOBase { }

    [FunctionOutput]
    public class LeaderboardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "user", 1)]
        public virtual string User { get; set; }
        [Parameter("uint256", "score", 2)]
        public virtual BigInteger Score { get; set; }
    }



    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }











    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
