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
    public AudioSource throwSound;
    [SerializeField] States currentState = States.idle;

    public enum States{
        idle,
        movingLeft,
        movingRight,
        jumping,
        isAttacking        
    }

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

            if(currentState != States.movingLeft && !Input.GetKey(jump)){
                SetCurrentState(States.movingLeft);
            }
        }
        else if(Input.GetKey(right)){
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            if (currentState != States.movingRight && !Input.GetKey(jump)){
                SetCurrentState(States.movingRight);
            }
        }
        else if(!Input.GetKey(jump)){
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (currentState != States.idle){
                SetCurrentState(States.idle);                
            }
        }

        jumping();
        checkRotation();      
    }

    void attack(){
        if (Input.GetKeyDown(throwBall)){
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
            throwSound.Play();
        }

        if (Input.GetKeyDown(throwBall) && currentState != States.isAttacking)
            SetCurrentState(States.isAttacking);        
    }

    void jumping(){
        if (Input.GetKeyDown(jump) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(jump) && currentState != States.jumping){
            SetCurrentState(States.jumping);
        }
    }

    void checkRotation(){
        if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (rb.velocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);        
    }

    public void SetCurrentState(States state){
        if(currentState != state){
            currentState = state;           
        }

        switch (currentState){
            case States.idle:
                Debug.Log("New State:" + States.idle);
                break;
            case States.movingLeft:
                Debug.Log("New State: Left " + States.movingLeft);
                break;
            case States.movingRight:
                Debug.Log("New State: Left " + States.movingRight);
                break;
            case States.jumping:
                Debug.Log("New State:" + States.jumping);
                break;
            case States.isAttacking:
                Debug.Log("New State:" + States.isAttacking);
                break;
            default:
                break;
        }
    }
}
