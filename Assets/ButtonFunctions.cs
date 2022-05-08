using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject Panel;
    public GameObject scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreKeeper == null)
            scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Play()
    {
        SceneManager.LoadScene("Part1");
    }

    public void Home()
    {
        SceneManager.LoadScene("Main");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Restart()
    {
        if (SceneManager.GetActiveScene().name == "Part1")
        {
            Panel.SetActive(false);
            // resume time
            Time.timeScale = 1.0f;
            // reset the score
            PersistantData.Instance.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
