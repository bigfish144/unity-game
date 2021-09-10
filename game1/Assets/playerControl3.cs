using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl3 : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Animator anim;
    public float speed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalmove = Input.GetAxis("Horizontal");
        float verical = Input.GetAxis("Vertical");
        float facedirction = Input.GetAxisRaw("Horizontal");
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


        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, 30);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(0, 0, -30);
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

    }
}
