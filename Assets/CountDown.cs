using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] float timer=60;
    [SerializeField] Text timerTxt;
    [SerializeField] GameObject controller;
    [SerializeField] GameObject Healthcontroller;
    int score;
    // Start is called before the first frame update
     void Start()
    {
      if(Healthcontroller==null){
        Healthcontroller= GameObject.FindGameObjectWithTag("Fish");
      }
      if (controller == null)
        controller = GameObject.FindGameObjectWithTag("ScoreKeeper");
        DisplayTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1*Time.deltaTime;
        DisplayTimer();
        if(timer<=0){

          score=Healthcontroller.GetComponent<Fish>().health*10;
        //  Debug.Log(score);
          controller.GetComponent<ScoreKeeper>().UpdateScore(score);
          SceneManager.LoadScene("WaterInfo");
        }
    }
    public void DisplayTimer(){
        timerTxt.text="Timer "+(int)timer;

    }
  
}
