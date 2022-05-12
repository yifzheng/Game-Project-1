using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] float timer=60;
    [SerializeField] Text timerTxt;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1*Time.deltaTime;
        DisplayTimer();
        if(timer<=0){
          SceneManager.LoadScene("WaterInfo");
        }
    }
    public void DisplayTimer(){
        timerTxt.text="Timer "+(int)timer;

    }
}
