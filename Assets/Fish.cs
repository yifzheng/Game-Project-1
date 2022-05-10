using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fish : MonoBehaviour
{

         
	public int health=20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	public void TakeDamage(int damage){
	
		health-=damage;
		if(health <=0){
			Destroy(gameObject);
            PersistantData.Instance.Reset(); // if health lower than 0, reset score and load to main
			SceneManager.LoadScene("Main");
		}
	
	
	}
}
