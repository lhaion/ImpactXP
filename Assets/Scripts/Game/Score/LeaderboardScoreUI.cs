using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScoreUI : MonoBehaviour
{
    public TMPro.TMP_Text walletText;
    public TMPro.TMP_Text scoreText;

    public void InitializeScoreUI(string wallet, string score)
    {
        walletText.text = wallet;
        scoreText.text = score;
    }



}
