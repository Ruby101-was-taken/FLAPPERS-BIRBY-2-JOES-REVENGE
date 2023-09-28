using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = -1.5f;
    public GameObject obstacle;
    public float height;
    public GameManager gameManager;

    private float spawnPos = 0f;
    // Update is called once per frame
    void Update()
    {
        if (time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            if (gameManager.gameMode == 0)
            {
                spawnPos = 0;
            }
            else if (gameManager.gameMode == 1)
            {
                spawnPos = -10;
            }
            go.transform.position = transform.position + new Vector3(spawnPos, Random.Range(-height, height), 0);
            
            time = 0;
            Destroy(go, 10);
        }
        time += Time.deltaTime;
    }

    public void reverseTime()
    {
        time = -10;
    }
}
