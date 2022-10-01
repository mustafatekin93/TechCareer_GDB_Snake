using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float minPosX;
    public float minPosY;
    public float maxPosX;
    public float maxPosY;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Snake")
        {
            SpawnRandom();
        }
    }

    void SpawnRandom()
    {
        transform.position = new Vector2(Random.Range(minPosX, maxPosX), Random.Range(minPosY, maxPosY));
    }
}
