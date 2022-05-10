using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject Panel;
    public GameObject MenuPanel;
    public GameObject scoreKeeper;
    public GameObject FactsPanel;
    public bool pause = false;
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
        PersistantData.Instance.Reset();
        ToggleMenuPanel();
        SceneManager.LoadScene("Main");
    }

    public void HighScoreToHome()
    {
        PersistantData.Instance.Reset();
        SceneManager.LoadScene("Main");
    }

    public void HighScores()
    {
        PlayerPrefs.SetInt("FromMenu", 1);
        SceneManager.LoadScene("HighScores");
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

    public void ToggleMenuPanel()
    {
        if (MenuPanel != null)
        {
            bool isActive = MenuPanel.activeSelf;
            pause = !pause;
            if (pause == true)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            MenuPanel.SetActive(!isActive);
        }
    }

    public void ToggleFactsPanel()
    {
        if (FactsPanel != null)
        {
            bool isActive = FactsPanel.activeSelf;
            FactsPanel.SetActive(!isActive);
        }
    }

    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
