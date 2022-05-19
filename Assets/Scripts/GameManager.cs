using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Text scoreText;
    public Text startText;
    public Text overText;

    public bool isGameStart = false;
    public bool isGameOver = false;
    public Rigidbody2D logoRb;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;

        startText = GameObject.Find("GameStartText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)    //isGameStart == false
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel(0);
            }
        }

    }

    public void AddScore()
    {
        score++;

        scoreText.text = "SCORE : " + score.ToString();
    }

    public void GameStart()
    {
        isGameStart = true;
        startText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        logoRb.simulated = true;

        Destroy(logoRb.gameObject, 1);
    }

    public void GameOver()
    {
        isGameOver = true;
        overText.gameObject.SetActive(true);
    }

}
