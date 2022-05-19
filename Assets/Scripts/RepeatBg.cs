using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    BoxCollider2D groundCol;
    float groundLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCol = GetComponent<BoxCollider2D>();
        groundLength = groundCol.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -groundLength)
        {
            RepositionBg();
        }
    }

    void RepositionBg()
    {
        Vector2 offset = new Vector2(groundLength * 2, 0);

        transform.position = (Vector2)transform.position + offset;
    }

}
