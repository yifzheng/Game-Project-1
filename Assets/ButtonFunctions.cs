using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
