using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            animator.SetTrigger("Attack");
            Invoke("StopAnim",0.4f);
        }
    }

    void StopAnim()
    {
        animator.SetTrigger("NoAttack");
    }
}
