using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour {

    public Text score,hiScore;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);
            score.text = PlayerPrefs.GetInt("score").ToString();
        }
        else
        {
            score.text = PlayerPrefs.GetInt("score").ToString();
        }

        if (!PlayerPrefs.HasKey("hiScore"))
        {
            PlayerPrefs.SetInt("hiScore", 0);
            hiScore.text = PlayerPrefs.GetInt("hiScore").ToString();
        }
        else
        {
            hiScore.text = PlayerPrefs.GetInt("hiScore").ToString();
        }
    }
    


}
