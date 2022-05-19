using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public float moveUpForce = 0;   //점프힘
    public float angle = 0; //이미지 각도
    public float rotSpeed = 0;  //이미지 회전 속도

    SpriteRenderer img;
    Rigidbody2D rb2d;

    bool isDead = false;

    bool isPush = false;
    float animTime = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //같은 게임오브젝트의 리지드바디 컴포넌트 가져옴
        img = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead || GameManager.gm.isGameStart == false) return;

        if (rb2d.simulated == false) rb2d.simulated = true;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            rb2d.velocity = Vector2.zero;       //현재 오브젝트에 적용된 물리값 리셋
            rb2d.AddForce(new Vector2(0, moveUpForce)); //위로 점프!!
            angle = 35;
            //isPush = true;
          //  animTime = 1;

            img.sprite = Resources.Load<Sprite>("AngryBirdJump");
        }               

        if(angle > -35)
        {
            angle -= Time.deltaTime * rotSpeed;     //시간에 회전 스피드를 곱한 값을 앵글에서 마이너스~~
            transform.localRotation = Quaternion.Euler(0, 0, angle);

            if (angle < 10)
            {
                img.sprite = Resources.Load<Sprite>("AngryBirdNormal");
            }
        }

        //if(isPush)
        //{
        //    animTime -= Time.deltaTime;
        //    if(animTime <= 0)
        //    {
        //        isPush = false;
        //        animTime = 1;
        //        img.sprite = Resources.Load<Sprite>("AngryBirdNormal");
        //    }
        //}

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GameManager.gm.GameOver();
        img.sprite = Resources.Load<Sprite>("AngryBirdDie");
    }

}
