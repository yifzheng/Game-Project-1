using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] int score;
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistantData.Instance.GetScore(); // get the score from persistant data and set it locally
        DisplayScore(); // display the score
    }

    // displayscore method
    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score; 
    }
    /* // update score will be called in Part1 only when the bird touches the key
        Once the bird touchs the key, the score is calculated and UpdateScore() is called with the score as the parameter
        We take the paramter and set it to score and call DisplayScore() to update the text
        Afterwards, call PerstantData and use IncrementScore() to update the highscore
        PlayerPrefs is created so we have a reference of the score in the next round should there be a gameover/reset
        <---------------------------------------------------------------->
        In part3, update score calls persistantdata and score is equal to playerprefs.getInt("Part1Score")
        When timer hits 0, score will be updated and scene will load next
    */
    public void UpdateScore(int sc)
    {
        score += sc;
        DisplayScore();
        PersistantData.Instance.IncrementScore(sc); // have persistant data update the score
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Score", sc); // save the level score in playerprefs, will delete at highscore page
    }
}
