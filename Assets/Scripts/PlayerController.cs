using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadious;
    public bool isGrounded;
    public LayerMask whatIsGround;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    private Animator anim;

    public GameObject snowBall;
    public Transform throwPoint;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, whatIsGround);

        movement();
        attack();

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }

    void movement()
    {
        if (Input.GetKey(left)){
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if(Input.GetKey(right)){
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(rb.velocity.x < 0){
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (rb.velocity.x > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void attack()
    {
        if (Input.GetKeyDown(throwBall)){
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
        }
    }
}
