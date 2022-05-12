using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public GameObject gameOverPanel; // gameover panel
    public Text fishHP;
	public int health=20;
    // Start is called before the first frame update
    void Start()
    {
        DisplayHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayHealth()
    {
        fishHP.text = "Health: " + health;
    }
	
    // toggle panel function
    public void TogglePanel()
    {
        gameOverPanel.SetActive(true);
    }
	
	public void TakeDamage(int damage){
	
		health-=damage;
        DisplayHealth();
		if(health <=0){
            TogglePanel();
            Time.timeScale = 0.0f;
		}
	
	
	}
}
