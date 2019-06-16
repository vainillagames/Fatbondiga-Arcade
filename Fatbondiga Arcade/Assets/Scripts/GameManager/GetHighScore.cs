using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    public Text scoreG;
    public Text score;
    public int scoreH;

    // Start is called before the first frame update
    void Start()
    {
        /*scoreH = 10;
        if (PlayerPrefs.GetInt("GameScore") > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreH);
        }*/
        
       score.text= PlayerPrefs.GetInt("HighScore").ToString();
        scoreG.text = PlayerPrefs.GetInt("GameScore").ToString();
    }

   
}
