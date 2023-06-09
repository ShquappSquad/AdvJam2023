using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    private float attackRange = 2.25f;
    public LayerMask enemyLayers;  

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
        
    }

    void Attack()
    {
        //Call Animation
        animator.SetTrigger("Attack");

        //Find Enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Apply Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            //Call Damage Flash script
            //enemy.GetComponent<DamageFlash>().FlashStart();

            //Subtract health from total
            if(enemy.name == "CEO")
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<CEOHealth>().TakeDamage();
            }
            if(enemy.name == "Worker - Pipe")
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<WorkerHealth>().TakeDamage();
            }
        }
    
    }


}
