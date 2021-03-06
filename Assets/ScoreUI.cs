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
        /* scoreManager.AddScore(new Score("John Doe", 260));
        scoreManager.AddScore(new Score("Jane Doe", 120)); */
        if (PlayerPrefs.GetInt("FromMenu") != 1)
        {
            scoreManager.AddScore(new Score(PlayerPrefs.GetString("PlayerName"), PersistantData.Instance.GetScore()));
            PlayerPrefs.DeleteKey("PlayerName");
        }
        else
        {
            PlayerPrefs.SetInt("FromMenu", 0);
        }
        //<---------------------------------------------------------->
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length && i != 5; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.playerName.text = scores[i].playerName;
            row.score.text = scores[i].score.ToString();
        }
    }

}