using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float acceleration;
    public float speedLimit;
    int status = 0;
    // Start is called before the first frame update

    bool QTE_A()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
                return true;
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x - 3f > 0 ? rb.velocity.x - 0.5f : 0, rb.velocity.y);
                return false;
            }
        }
        return false;
    }

    bool QTE_D()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
                return true;
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x - 3f > 0 ? rb.velocity.x - 0.5f : 0, rb.velocity.y);
                return false;
            }
        }
        return false;
    }

    bool QTE_W()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
                return true;
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x - 3f > 0 ? rb.velocity.x - 0.5f : 0, rb.velocity.y);
                return false;
            }
        }
        return false;
    }

    bool QTE_S()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
                return true;
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x - 3f > 0 ? rb.velocity.x - 0.5f : 0, rb.velocity.y);
                return false;
            }
        }
        return false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (status == 0)
        {
            if (QTE_A())
            {
                status = 1;
            }
        }
        else if (status == 1)
        {

            if (QTE_D())
            {
                status = 2;
            }
        }
        else if (status == 2)
        {

            if (QTE_W())
            {
                status = 3;
            }
        }
        else if (status == 3)
        {

            if (QTE_S())
            {
                status = 0;
            }
        }
    }
}
