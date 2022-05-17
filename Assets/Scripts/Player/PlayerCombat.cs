using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    [SerializeField] GameObject attackSound;
    [SerializeField] float attackRate = 2f;
    float nextAttackTime = 0f;


    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");
            var instatiatedAttackSound = Instantiate(attackSound, gameObject.transform.position, Quaternion.identity);
            Destroy(instatiatedAttackSound, 1f);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
