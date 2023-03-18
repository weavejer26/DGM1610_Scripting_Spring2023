using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Stats
    [Header("Player Stats")]
    public float speed; //How fast the player is going to move
    public float jumpForce; //How high the player will jump
    private float moveInput; //Get move input value

    //Player RigidBody
    [Header("Player Rigidbody Component")]
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    //Player Jump
    [Header("Jump Settings")]
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool doubleJump;
    
    // Start is called before the first frame update
    void Start()
    {
      //Get Rigidbody Component Reference
      rb = GetComponent<Rigidbody2D>();  
    }
    
    //FIxed Update is called a fixed or set number of frames. This works best with physics based movement.
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //Define what is the ground

        moveInput = Input.GetAxis("Horizontal"); //Get the Horizontal Keybinding
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //Move Player Left and Right

        //If the player is moving right but facing left flip the player right
        if(!isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }
        //If the player is moving left but facing right flip the player left
        else if(isFacingRight && moveInput < 0);
        {
            FlipPlayer();
        }
    }

    //Update is called once per frame. we will use Update for the jump as we will need every frame
    void Update() 
    {
       if(isGrounded) 
        {
            doubleJump = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce; //Makes the Player jump
            doubleJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce; //Apply force to Player making them jump
        }
    }
        
    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //Local variable that stores localscale value
        scaler.x *= -1; //Flip the Sprite graphic
        transform.localScale = scaler;
    }
}
