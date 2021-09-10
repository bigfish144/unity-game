using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class playerControl4 : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Text text;
    public Text lifeNum;
    public Text GAMEOVER;
    public Text stepNum;
    public Text WIN;
    public Tilemap tilemap;

    int numbers = 0;
    int lifeN = 5;
    int step = 0;
    static Vector3Int mapPosition;


    // Start is called before the first frame update
    void Start()
    {
        mapPosition = new Vector3Int((int)(transform.position.x-1), (int)transform.position.y, (int)transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
            step += 1;
            mapPosition = new Vector3Int(mapPosition.x+1, mapPosition.y, mapPosition.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
            step += 1;
            mapPosition = new Vector3Int(mapPosition.x - 1, mapPosition.y, mapPosition.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -1, 0);
            step += 1;
            mapPosition = new Vector3Int(mapPosition.x, mapPosition.y - 1, mapPosition.z);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 1, 0);
            step += 1;
            mapPosition = new Vector3Int(mapPosition.x, mapPosition.y + 1, mapPosition.z);
        }
        text.text = numbers.ToString();
        lifeNum.text = lifeN.ToString();
        stepNum.text = step.ToString();
        tilemap.SetTile(mapPosition, null);
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (lifeN > 0)
            {
                transform.position = new Vector3(-3.49f, 3.69f, 0);
                mapPosition = new Vector3Int((int)(transform.position.x - 1), (int)transform.position.y, (int)transform.position.z);
                lifeN -= 1;
            }
            else
            {
                Destroy(rb.gameObject);
                GAMEOVER.text = "GAME OVER";
            }
        }
        if (collision.gameObject.tag == "Cover")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Win")
        {
            Destroy(rb.gameObject);
            WIN.text = "YOU WIN!";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            numbers += 1;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            numbers -= 1;
        }

    }
}
