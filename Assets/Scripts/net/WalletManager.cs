using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FusedVR.Web3;


public class WalletManager : MonoBehaviour
{
    
    public TMPro.TMP_InputField emailInput;
    public void TryToConnectWallet()
    {
        ConnectWallet();
    }

    public async void ConnectWallet()
    {
        GameEvents.instance.TryWalletConnection();

        string walletEmail = emailInput.text;

        bool connection = false;// = await Web3Manager.Login("", walletEmail);
        float timeout = 30f;
        
        while(!connection)
        {
            connection = await Web3Manager.Login("", walletEmail);
        }

        if (connection)
        {
            GameManager.instance.Wallet = await Web3Manager.GetAddress();
            GameEvents.instance.WalletConnected();
            
        }

        else
            GameEvents.instance.WalletError();
    }
}
