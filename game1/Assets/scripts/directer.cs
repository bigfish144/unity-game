using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class directer : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject dis;
    // Start is called before the first frame update
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.dis = GameObject.Find("dis");
    }

    // Update is called once per frame
    void Update()
    {
        float len = this.flag.transform.position.x - car.transform.position.x;
        this.dis.GetComponent<Text>().text = "距离目标" + len.ToString(format: "F2") + "m";

    }
}
