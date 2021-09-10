using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float acceleration;
    public float jumpforce;
    public float speedLimit;
    public int distanceGap;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {


        Vector3 mousePosition = Input.mousePosition;
        //鼠标与角色间距
        float disX = mousePosition.x - transform.position.x - 200;
        float disY = mousePosition.y - transform.position.y - 140;
        int XPos = disX >= 0 ? 1 : -1;
        int YPos = disY >= 0 ? 1 : -1;

        float sumDis = Mathf.Sqrt(disX * disX + disY * disY);
        float speedX;
        float speedY;

        //加速代码，第一执行
        if (sumDis >= distanceGap)
        {

            float sinForY = disY / sumDis;
            float cosForX = disX / sumDis;

            speedX = rb.velocity.x + acceleration * (disX - distanceGap * cosForX)/ 300;
            speedY = rb.velocity.y + acceleration * (disY - distanceGap * sinForY)/ 300;
            rb.velocity = new Vector2(speedX, speedY);
        }



        //限速代码，第二执行
        speedX = rb.velocity.x;
        speedY = rb.velocity.y;
        float sumSpeed = Mathf.Sqrt(speedX * speedX + speedY * speedY);
        if (sumSpeed > speedLimit)
        {
            float limitRate = speedLimit / sumSpeed;

            rb.velocity = new Vector2(rb.velocity.x * limitRate, rb.velocity.y * limitRate);
        }

        //减速代码，第三执行
        float horizontalmove = Input.GetAxis("Horizontal");


        if (horizontalmove != 0 || sumDis < distanceGap)
        {
            speedX = rb.velocity.x;
            speedY = rb.velocity.y;
            sumSpeed = Mathf.Sqrt(speedX * speedX + speedY * speedY);

            float sinForY = speedY / sumSpeed;
            float cosForX = speedX / sumSpeed;

            rb.velocity = new Vector2(rb.velocity.x - cosForX * acceleration * 3.5f, rb.velocity.y - sinForY * acceleration * 3.5f);
            if(sumSpeed < 5)
                rb.velocity = new Vector2(0, 0);
        }




        /*
         * 
         * 
         * 
         * 
              
        
        if (horizontalmove != 0)
        {
        float horizontalmove = Input.GetAxis("Horizontal");
        float verical = Input.GetAxis("Vertical");
        float facedirction = Input.GetAxisRaw("Horizontal");
        Vector3 mousePosition = Input.mousePosition;

        float disX = mousePosition.x - transform.position.x - 400;
        float disY = mousePosition.y - transform.position.y - 150;
            //float changeX = rb.velocity.x - 3 * Mathf.Abs(disX) * speed * Time.deltaTime * rb.velocity.x / sumSpeed;
            //float changeY = rb.velocity.y - 3 * Mathf.Abs(disY) * speed * Time.deltaTime * rb.velocity.y / sumSpeed;
            float changeX = rb.velocity.x - 0.1f * positiveTest(rb.velocity.x) * Mathf.Abs(rb.velocity.x / sumSpeed);
            float changeY = rb.velocity.y - 0.1f * positiveTest(rb.velocity.y) * Mathf.Abs(rb.velocity.y / sumSpeed);
            if (positiveTest(rb.velocity.x) != positiveTest(changeX))
            {
                changeX = 0;
            }
            if (positiveTest(rb.velocity.y) != positiveTest(changeY))
            {
                changeY = 0;
            }
            rb.velocity = new Vector2(changeX, changeY);
  
            if (Mathf.Abs(rb.velocity.x)<5)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            if (Mathf.Abs(rb.velocity.y) < 5)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

        }
        
        
        if (horizontalmove != 0 || verical != 0)
                {
                    float changeX = rb.velocity.x - 10 * positiveTest(rb.velocity.x) * disX * speed * Time.deltaTime;
                    float changeY = rb.velocity.y - 10 * positiveTest(rb.velocity.y) * disY * speed * Time.deltaTime;
                    if (positiveTest(rb.velocity.x) == positiveTest(changeX))
                    {
                        rb.velocity = new Vector2(changeX, rb.velocity.y);
                    }
                    else
                    {

                    }
                    if (positiveTest(rb.velocity.y) == positiveTest(changeY))
                        rb.velocity = new Vector2(rb.velocity.x, changeY);

                }

                //判断角色移动
                if (horizontalmove != 0)
                {
                    rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);
                    anim.SetFloat("runningTest", Mathf.Abs(facedirction));
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);

                }
                //判断角色方向
                if (facedirction != 0)
                {
                    transform.localScale = new Vector3(facedirction, 1, 1);
                }

                //判断角色移动
                if (verical != 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, verical * speed * Time.deltaTime);
                    anim.SetFloat("runningTest", Mathf.Abs(facedirction));
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);

                }


                if (rb.velocity.y > 0)
                {
                    anim.SetFloat("runningTest", 0);
                    anim.SetBool("upTest", true);
                    anim.SetBool("downTest", false);
                }
                else if (rb.velocity.y < 0)
                {
                    anim.SetFloat("runningTest", 0);
                    anim.SetBool("upTest", false);
                    anim.SetBool("downTest", true);

                }
                else
                {
                    anim.SetBool("upTest", false);
                    anim.SetBool("downTest", false);
                }

                */
    }


}
