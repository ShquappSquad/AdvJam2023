using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float playerScale = 0.85f;

    public float detectDistance = 10.0f;
    public float attackDistance = 2.5f;
    
    public Rigidbody2D rb;
    public Animator animator;
    public Rigidbody2D player;

    private bool chasing = false;
    private bool isSwinging = false;

    private const float attackDistYScalar = 0.3f;

    Vector2 movement;

    // Update is called once per frame which makes it bad for physics calculations
    void Update()
    {
        if (player != null)
        {
            if (!isSwinging)
            {
                Vector3 offset = player.position - rb.position;
                float magnitude = offset.magnitude;
                if (!chasing)
                {
                    if (magnitude <= detectDistance)
                    {
#if WORKER_DEBUG
                        Debug.Log("graaa!!!");
#endif
                        chasing = true;
                    }
                }

                if (chasing)
                {
                    if (magnitude <= attackDistance && Mathf.Abs(offset.y) < (attackDistance * attackDistYScalar))
                    {
                        isSwinging = true;
                        // stop moving
                        movement.x = 0.0f;
                        movement.y = 0.0f;
                        Invoke("EndAttack", 0.8f);
#if WORKER_DEBUG
                        Debug.Log("attack time!");
#endif
                    }
                    else
                    {
                        // actually try to move to be on same y as player
                        if (offset.x < 0.0f)
                        {
                            offset.x = offset.x + (attackDistance * attackDistYScalar);
                        }
                        else
                        {
                            offset.x = offset.x - (attackDistance * attackDistYScalar);
                        }

                        offset = ConvertTo8Dir(offset);

                        magnitude = offset.magnitude;

                        transform.Translate(new Vector3((offset.x * moveSpeed), (offset.y * moveSpeed), 0) * Time.deltaTime);
                    }
                }

                //Call animations
                //animator.SetFloat("Horizontal", movement.x);
                // animator.SetFloat("Speed", movement.sqrMagnitude);
            }
        }
    }

    void EndAttack()
    {
#if WORKER_DEBUG
        Debug.Log("okey i done attack");
#endif
        isSwinging = false;
    }

    // FixedUpdate will be called a fixed number of times per second regardless of frame rate
    void FixedUpdate()
    {
        //Left/Right Movement 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // converts a vector to a standard 8-direction vector
    private static Vector3 ConvertTo8Dir(Vector3 vector)
    {
        Vector3 ret = new Vector3(0.0f, 0.0f, 0.0f);
        // lock x to +1, 0, or -1
        if (vector.x > 0.0f)
        {
            ret.x = 1.0f;
        }
        else if (vector.x < 0.0f)
        {
            ret.x = -1.0f;
        }

        // lock y to +1, 0, or -1
        if (vector.y > 0.0f)
        {
            ret.y = 1.0f;
        }
        else if (vector.y < 0.0f)
        {
            ret.y = -1.0f;
        }

        if (ret.y != 0.0f && ret.x != 0.0f)
        {
            ret.x = ret.x / 1.4f;
            ret.y = ret.y / 1.4f;
        }
        return ret;
    }
}

