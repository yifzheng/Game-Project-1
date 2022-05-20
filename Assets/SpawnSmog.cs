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
        InvokeRepeating("Spawn", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int xMin = -10;
        int xMax = 10;
        int yMin = -5;
        /* for (int i = 0; i < numOfSmog; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), yMin);
            Instantiate(smogObj, position, Quaternion.identity);
        } */
        Vector2 position = new Vector2(Random.Range(xMin, xMin + 4), yMin);
        Instantiate(smogObj, position, Quaternion.identity);
        Vector2 position2 = new Vector2(Random.Range(xMin + 4, -2), yMin);
        Instantiate(smogObj, position2, Quaternion.identity);
        Vector2 position3 = new Vector2(Random.Range(-2, 2), yMin);
        Instantiate(smogObj, position3, Quaternion.identity);
        Vector2 position4 = new Vector2(Random.Range(2, 6), yMin);
        Instantiate(smogObj, position4, Quaternion.identity);
        Vector2 position5 = new Vector2(Random.Range(6, xMax), yMin);
        Instantiate(smogObj, position5, Quaternion.identity);
    }
}
