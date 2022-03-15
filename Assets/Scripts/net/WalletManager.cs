using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletManager : MonoBehaviour
{
    public TMPro.TMP_InputField emailInput;
    public void TryToConnectWallet()
    {
        StartCoroutine(ConnectWallet());
    }

    private IEnumerator ConnectWallet()
    {
        GameEvents.instance.TryWalletConnection();

        string walletEmail = emailInput.text;

        bool connection = /*Await here*/ false;
        float timeout = 30f;
        
        while(!connection || timeout > 0)
        {
            timeout--;
            yield return new WaitForSeconds(1);
        }
        
        if(connection)
            GameEvents.instance.WalletConnected();
        else
            GameEvents.instance.WalletError();
    }
}
