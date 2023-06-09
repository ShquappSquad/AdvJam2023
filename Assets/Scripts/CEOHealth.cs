using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEOHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage()
    {
        currentHealth --;

        Debug.Log(name + " has " + currentHealth + " health");

        if(currentHealth <= 2)
        {
            Debug.Log("WE NEED BACKUP. SEND IN KEVIN.");
            animator.SetTrigger("Phone");
        }
        
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
