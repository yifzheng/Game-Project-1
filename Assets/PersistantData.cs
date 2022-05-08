using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    [SerializeField] int highScore; // variable to store the highscore of the game session

    public static PersistantData Instance; // create an instance of persistancedata so methods and variables are accessible across files

    void Awake()
    {
        // if Instance object is null on destory this script and set the instance to Instance
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = 0;
    }

    // increment score method
    public void IncrementScore(int score)
    {
        highScore += score;
    }

    // set score method
    public void SetScore(int score)
    {
        highScore = score;
    }

    // get score method
    public int GetScore()
    {
        return highScore;
    }


}
