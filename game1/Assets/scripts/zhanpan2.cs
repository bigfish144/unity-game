using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhanpan2 : MonoBehaviour
{
    private float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.speed = 10;
        }
        transform.Rotate(xAngle: 0, yAngle: 0, zAngle: speed);
        speed *= 0.98f;
        if (speed < 0.0001f)
        {
            speed = 0;
            
        }
    }
}
