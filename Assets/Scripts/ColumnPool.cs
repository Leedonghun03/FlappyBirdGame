using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    const int columnSize = 5;

    public GameObject columnPrefab;

    public float spwanRate = 3;
    public float minY = -1;
    public float maxY = 3.5f;
        
    GameObject[] pool = new GameObject[columnSize];

    int currnetColumn = 0;

    public Vector2 spawnPosition = new Vector2(12, 50);
    public float rePosX = 12;

    float time = 0;



    // Start is called before the first frame update
    void Start()
    {
       for(int i =0; i < pool.Length; i++)
       {
            pool[i] = Instantiate(columnPrefab, spawnPosition, Quaternion.identity);
       }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.isGameStart == false || GameManager.gm.isGameOver == true) return;

        time += Time.deltaTime;

        if(time >= spwanRate)
        {
            SpawnCol();
        }
    }

    void SpawnCol()
    {
        time = 0;

        float y = Random.Range(minY, maxY);

        pool[currnetColumn].transform.position = new Vector2(rePosX, y);

        currnetColumn++;

        if(currnetColumn >= columnSize)
        {
            currnetColumn = 0;
        }

    }


}
