using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    private float speed = 0;
    public Vector2 starPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.starPos = (Vector2)Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = (Vector2)Input.mousePosition;
            float len = endPos.x - starPos.x;
            this.speed = len / 1600.0f;
            GetComponent<AudioSource>().Play();
        }
        transform.Translate(x: this.speed, y: 0, z: 0);
        this.speed *= 0.98f;
        

    }
}
