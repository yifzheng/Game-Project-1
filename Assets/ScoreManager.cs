using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    // Start is called before the first frame update
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }
    // get highscores in descending order
    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score).ThenBy(x => x.playerName);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    public void Clear()
    {
        sd.scores.Clear();
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }

}