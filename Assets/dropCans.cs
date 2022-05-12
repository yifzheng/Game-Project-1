using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropCans : MonoBehaviour
{
	public GameObject canPrefab;
	public float respawnTime = 2.0f;
	private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.x));
		StartCoroutine(littering());
		StartCoroutine(littering());
		StartCoroutine(littering());
		StartCoroutine(littering());
    }


	private void spawnCan(){
		GameObject a = Instantiate(canPrefab) as GameObject;
		a.transform.position=new Vector2(Random.Range(-screenBounds.x,screenBounds.x), Random.Range(screenBounds.y,screenBounds.y));



	}
	IEnumerator littering(){
		while(true){
			yield return new WaitForSeconds(Random.Range(1f,3f));
			spawnCan();



		}
	}
    // Update is called once per frame
    void Update()
    {

    }
}
