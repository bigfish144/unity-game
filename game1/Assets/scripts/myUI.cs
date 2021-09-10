using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerleftmove(string name)
    {
        
        GameObject player = GameObject.Find(name);
        if (player.transform.position.x < -5)
        {
            player.transform.position = new Vector3(-5.67f, -3.64f, 0);
        }
        else
        {
            player.transform.position += new Vector3(-3, 0, 0);
        }
       
        
    }
    public void playerrighttmove(string name)
    {
        GameObject player = GameObject.Find(name);
        if (player.transform.position.x > 6)
        {
            player.transform.position = new Vector3(6.33f, -3.64f, 0);
        }
        else
        {
            player.transform.position += new Vector3(3, 0, 0);
        }
        
    }
    public void playagain(string name)
    {
        GameObject panel = GameObject.Find(name);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
