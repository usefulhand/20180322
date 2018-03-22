using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (player.GetComponent<AttackScript>().comSlot)
        {
            case 0:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15.0f), ForceMode2D.Impulse);
                player.GetComponent<AttackScript>().comSlot = 999;
                break;
            case 1:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -30.0f), ForceMode2D.Impulse);
                player.GetComponent<AttackScript>().comSlot = 999;
                break;
            case 2:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20.0f, 0.0f), ForceMode2D.Impulse);
                player.GetComponent<AttackScript>().comSlot = 999;
                break;
            case 999:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3.0f, 0f), ForceMode2D.Impulse);
                player.GetComponent<AttackScript>().comSlot = 999;
                break;
            default:
                break;
        }
        print(player.GetComponent<AttackScript>().comSlot);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
