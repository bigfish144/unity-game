using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cat;
    float randtime;
    
    public Animator anim;
    public GameObject xuetiao;
    public GameObject panel;
    

    void Start()
    {
        cat = GameObject.Find("player");
        anim = GameObject.Find("player").GetComponent<Animator>();
        PlayerPrefs.SetInt("count", 1);
        xuetiao.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 60);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        randtime = Random.Range(0.0f, 2.0f);
        transform.Translate(0, -0.2f, 0);
        Vector2 p1 = transform.position;//arrow
        Vector2 p2 = cat.transform.position;//cat
        Vector2 dis = p2 - p1;
        float d = dis.magnitude;
        float r1 = 0.5f; //arrow
        float r2 = 0.5f; //cat
        if (d < r1 + r2)
        {
            gameObject.SetActive(false);
            Invoke("recreate", randtime);
            anim.SetBool("hurt", true);
            
            xuetiao.GetComponent<RectTransform>().sizeDelta = new Vector2(300-(60* PlayerPrefs.GetInt("count")),60);
            PlayerPrefs.SetInt("count",PlayerPrefs.GetInt("count")+1);
            if (xuetiao.GetComponent<RectTransform>().sizeDelta.x<=0)
            {
                endgame();
            }
        }
        else if (transform.position.y < -4.02f)
        {
            Invoke("recreate", randtime);
            
        }
    }
    void recreate()
    {
        gameObject.SetActive(true);
        anim.SetBool("hurt", false);
        float randheight = Random.Range(10, 18);
        transform.position = new Vector3(transform.position.x, randheight, 0);
    }

    void endgame()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}