using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.isGameStart == false) return;

        if(GameManager.gm.isGameOver == false)
        {
            rb2d.velocity = new Vector2(-1.5f, 0);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }

    }
}
