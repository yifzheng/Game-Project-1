using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo){
    	
    	Fish fish= hitInfo.GetComponent<Fish>();
	if(fish !=null){
		fish.TakeDamage(5);

	}
    	Destroy(gameObject);
    
    
    }
}
