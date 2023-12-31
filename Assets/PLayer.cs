using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public GameManager gameManager;
    public bool isDead = false;
    public float velocoty = 2.4f;
    public Obsticals obsticals;
    
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rigidbody.velocity = Vector2.up * velocoty;
        }
        if (gameManager.gameMode == 0)
        {
            if (transform.position.x > -1.81f && transform.position.x <= 1.81f)
            {
                transform.position += ((Vector3.left * obsticals.speed) * Time.deltaTime);
            }
        }
        else if (gameManager.gameMode == 1)
        {
            if (transform.position.x >= -1.81f && transform.position.x < 1.81f)
            {
                transform.position += ((Vector3.right * obsticals.speed) * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameManager.GameOver();
    }
}
