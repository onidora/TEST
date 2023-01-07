using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject origin;
    public float interval = 2.0f;
   
    public Vector2 spawnRangeMax;
    public Vector2 spawnRangeMin;
    public int maxCount = 50;

    private float timeElapsed = 0.0f;
    private int count = 0;

    private void FixedUpdate()
    {
        if (maxCount <= count) return;

        timeElapsed += Time.fixedDeltaTime;

        if (interval < timeElapsed) 
        {

            float offsetX = Random.Range(spawnRangeMax.x, spawnRangeMin.x); 
            float offsetY = Random.Range(spawnRangeMax.y, spawnRangeMin.y); 

            Vector2 position = new Vector2(player.transform.position.x + offsetX, player.transform.position.y + offsetY);
            Instantiate(origin, position, Quaternion.identity);

            count++;
            timeElapsed = 0.0f;
        }
    }
}
