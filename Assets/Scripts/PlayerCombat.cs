using System;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange = 0.5f;
    public int attackDamage;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    void Start()
    {
        try
        {
            animator = gameObject.GetComponent<Animator>();
        }
        catch (Exception e)
        {
            Console.WriteLine("Please provide animator for: " + gameObject.name);
            throw;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRange;
            }   
        }
    }

    void Attack()
    {
        //Play an atttack animator
        animator.SetTrigger("Attack");
        
        //Detecet enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //Damage them
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint.Equals(null))
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
