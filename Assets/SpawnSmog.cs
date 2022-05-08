using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSmog : MonoBehaviour
{
    [SerializeField] GameObject smogObj;
    
    // Start is called before the first frame update
    void Start()
    {
        // In 0 seconds, call the spawn function. Repeat after every 2.5 seconds;
        InvokeRepeating("Spawn", 0.0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int numOfSmog = 7;
        int xMin = -10;
        int xMax = 10;
        int yMin = -5;
        for (int i = 0; i < numOfSmog; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), yMin);
            Instantiate(smogObj, position, Quaternion.identity);
        }
    }
}
