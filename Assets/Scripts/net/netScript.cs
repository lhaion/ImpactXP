using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NETHEREUM(github) libs, files locates at ./assets/plugins
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
using Nethereum.Contracts;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.Extensions;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.TransactionManagers;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3.Accounts;



public class netScript : MonoBehaviour
{




    public string Url = "https://ropsten.infura.io/v3/f51fc6313a05426899183b87a05ff580"; //testnet remote node ropsten
    public string PrivateKey = ""; //signkeys
    public string AddressTo = ""; //receiver
    public decimal Amount = 0; 
    public decimal GasPriceGwei = 0;
    public string TransactionHash = "";
    public decimal BalanceAddressTo = 0m;
    public string ResultBalanceAddressTo;
    public string ResultTxnHash;

    void Start()
    {
        Debug.Log("ETH script start");
        Debug.Log(GameManager.instance.GetPot());
    }
    
public void TransferRequest()
    {
        StartCoroutine(TransferEther());
    }

    public IEnumerator TransferEther()
    {
        
        var ethTransfer = new EthTransferUnityRequest(Url, PrivateKey, 444444444500);

        var receivingAddress = AddressTo;

        var feeStrategy = FeeStrategy.MedianFeeHistory;
        
        Debug.Log(feeStrategy == FeeStrategy.TimePreference);
        
        if (feeStrategy == FeeStrategy.TimePreference)
        {
            Debug.Log("Time Preference");
            var timePreferenceFeeSuggestion = new TimePreferenceFeeSuggestionUnityRequestStrategy(Url);

            yield return timePreferenceFeeSuggestion.SuggestFees();

            if (timePreferenceFeeSuggestion.Exception != null)
            {
                Debug.Log(timePreferenceFeeSuggestion.Exception.Message);
                yield break;
            }

            Debug.Log(timePreferenceFeeSuggestion.Result.Length);
            
            if (timePreferenceFeeSuggestion.Result.Length > 0)
            {
                Debug.Log(timePreferenceFeeSuggestion.Result[0].MaxFeePerGas);
                Debug.Log(timePreferenceFeeSuggestion.Result[0].MaxPriorityFeePerGas);
            }
            var fee = timePreferenceFeeSuggestion.Result[0];

            yield return ethTransfer.TransferEther(receivingAddress, Amount, fee.MaxPriorityFeePerGas.Value, fee.MaxFeePerGas.Value);
            if (ethTransfer.Exception != null)
            {
                Debug.Log("Error transferring Ether using Time Preference Fee Estimation Strategy: " + ethTransfer.Exception.Message);
                yield break;
            }
        }


        if(feeStrategy == FeeStrategy.MedianFeeHistory)
        {
            Debug.Log("MedianFeeHistory mode");
            var medianPriorityFeeStrategy = new MedianPriorityFeeHistorySuggestionUnityRequestStrategy(Url);

            yield return medianPriorityFeeStrategy.SuggestFee();

            if (medianPriorityFeeStrategy.Exception != null)
            {
                Debug.Log(medianPriorityFeeStrategy.Exception.Message);
                yield break;
            }

            var fee = medianPriorityFeeStrategy.Result;

            yield return ethTransfer.TransferEther(receivingAddress, Amount, fee.MaxPriorityFeePerGas.Value, fee.MaxFeePerGas.Value);
            if (ethTransfer.Exception != null)
            {
                Debug.Log("Error transferring Ether using Median Fee History Fee Estimation Strategy: " + ethTransfer.Exception.Message);
                yield break;
            }
        }

        if (feeStrategy == FeeStrategy.Legacy)
        {
            Debug.Log("Legacy mode");
            
            ethTransfer.UseLegacyAsDefault = true;

            yield return ethTransfer.TransferEther(receivingAddress, Amount, GasPriceGwei);

            if (ethTransfer.Exception != null)
            {
                Debug.Log("Error transferring Ether using Legacy Gas Price:  " + ethTransfer.Exception.Message);
                yield break;
            }

        }
        
        TransactionHash = ethTransfer.Result;
        
        ResultTxnHash = TransactionHash;
        
        Debug.Log("Transfer transaction hash:" + TransactionHash);
        
        var transactionReceiptPolling = new TransactionReceiptPollingRequest(Url);
        
        yield return transactionReceiptPolling.PollForReceipt(TransactionHash, 2);
        
        Debug.Log("Transaction mined");

        var balanceRequest = new EthGetBalanceUnityRequest(Url);
        yield return balanceRequest.SendRequest(receivingAddress, BlockParameter.CreateLatest());

        BalanceAddressTo = UnitConversion.Convert.FromWei(balanceRequest.Result.Value);
        ResultBalanceAddressTo = BalanceAddressTo.ToString();

        Debug.Log("Balance of account:" + BalanceAddressTo);
    }
    
    public enum FeeStrategy
    {
        Legacy,
        TimePreference,
        MedianFeeHistory
    }
    
    
    
    
    
    // any questions lrovaris#4065

}
