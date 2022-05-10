using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        // testing
        scoreManager.AddScore(new Score("John Doe", 260));
        scoreManager.AddScore(new Score("Jane Doe", 120));
        /* if (PlayerPrefs.GetInt("FromMenu") != 1)
        {
            scoreManager.AddScore(new Score(PlayerPrefs.GetInt("PlayerDartCount", 0), PlayerPrefs.GetInt("PlayerScore", 0)));
            PlayerPrefs.DeleteKey("PlayerDartCount");
            PlayerPrefs.DeleteKey("PlayerScore");
        }
        else
        {
            PlayerPrefs.SetInt("FromMenu", 0);
        } */
        //<---------------------------------------------------------->
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (i != 5)
            {
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row.rank.text = (i + 1).ToString();
                row.playerName.text = scores[i].playerName;
                row.score.text = scores[i].score.ToString();
            }
            else
            {
                break;
            }
        }
    }

}