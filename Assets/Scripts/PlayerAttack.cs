using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private bool isSwinging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSwinging)
            {
                isSwinging = true;
                Debug.Log("Attack");
                animator.SetTrigger("Attack");
                Invoke("StopAnim", 0.4f);
            } else
            {
                Debug.Log("no spammy >:(");
            }
        }
    }

    void StopAnim()
    {
        animator.SetTrigger("NoAttack");
        isSwinging = false;
    }
}
