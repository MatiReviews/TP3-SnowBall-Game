using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float ballSpeed;

    private Rigidbody2D rb;

    public GameObject snowBallEffect;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        movement();
    }

    void movement(){
        rb.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        checkPlayerCollision(collision);
        Instantiate(snowBallEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void checkPlayerCollision(Collider2D collision)
    {
         if(collision.tag == "Player1"){
            FindObjectOfType<GameManager>().HurtP1();
        }

        if (collision.tag == "Player2"){
            FindObjectOfType<GameManager>().HurtP2();
        }
    }
}
