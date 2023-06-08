using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    private float attackRange = 2;
    public LayerMask enemyLayers;  
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
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
            Debug.Log("We hit " + enemy.name);
        }
    
    }


}
