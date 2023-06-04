using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float playerScale = 0.85f;
    public float jumpHeight = 50f;
    //private float gravity = -1f;
    private float velocity;
    public Rigidbody2D rb;
    public Animator animator;
    private bool grounded = true;
    private bool left, right = false;
    
    Vector2 movement;

    // Update is called once per frame which makes it bad for physics calculations
    void Update()
    {
        //Player Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //Jump Input and execution
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            velocity = jumpHeight;
            //Delay X seconds
            Invoke("JumpFloat", 0.2f);
        }
        transform.Translate(new Vector3(movement.x * moveSpeed, (movement.y * moveSpeed) + velocity, 0) * Time.deltaTime);

        //Record which direction the player was facing last
        if(movement.x < 0)
        {
            animator.SetTrigger("Left");
#if PLAYER_DEBUG
            Debug.Log("Left");
#endif
        }
        if(movement.x > 0)
        {
            animator.SetTrigger("Right");
#if PLAYER_DEBUG
            Debug.Log("Right");
#endif
        }

       //Call waLking animations animations
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // FixedUpdate will be called a fixed number of times per second regardless of frame rate
    void FixedUpdate()
    {
        //Left/Right Movement 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);        
    }

    //Buffer function to increase hangtime when jumping
    void JumpFloat()
    {
        velocity = 0;
        Invoke("EnableGravity", 0.1f);
    }

    void EnableGravity()
    {
        velocity = -jumpHeight;
        transform.Translate(new Vector3(movement.x * moveSpeed, (movement.y * moveSpeed) + velocity, 0) * Time.deltaTime);
        //Delay X seconds             
        Invoke("DisableGravity", 0.2f);
    }

    void DisableGravity()
    {
        velocity = 0;
        grounded = true;
    }
}

