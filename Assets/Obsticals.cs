using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticals : MonoBehaviour
{
    public PLayer player;
    public float speed;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            if (gameManager.gameMode == 0)
            {
                transform.position += ((Vector3.left * speed) * Time.deltaTime);
            }
            else if (gameManager.gameMode == 1)
            {
                transform.position += ((Vector3.right * speed) * Time.deltaTime);
            }
        }
    }
}
