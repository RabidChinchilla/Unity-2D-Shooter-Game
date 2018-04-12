using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int theScore);
    public static event SendScore OnSendScore;
    public int score = 10;

    public void DoSendScore()
    {
        if (OnSendScore != null)
        {
            OnSendScore(score);
        }
    }
}
