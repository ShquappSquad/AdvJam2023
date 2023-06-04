using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public float maxHealth;
    public Image h1, h2, h3;
    private float currentHealth;
    private bool damaged = false;
    public SpriteRenderer render;

    private bool invulnerable;

    private static float invulnerableDuration = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 2)
        {
            h1.transform.localScale = new Vector3(0, 0, 0);
        }
        if(currentHealth <= 1)
        {
            h2.transform.localScale = new Vector3(0, 0, 0);
        }
        if(currentHealth <= 0)
        {
            h3.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    //Change this to happen when getting hit by an enemy, not colliding with props
    void OnTriggerEnter2D(Collider2D other)
    {
        if(damaged == false)
        {
            TakeDamage();
        } 
    }

    private void TakeDamage()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            currentHealth--;
            animator.SetTrigger("IsDamaged");

            Invoke("EndInvulnerable", invulnerableDuration);
        }
    }

    void EndInvulnerable()
    {
        invulnerable = false;
    }
}
