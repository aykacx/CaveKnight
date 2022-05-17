using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int enemyMaxHealth;
    private int enemyCurrentHealth;

    private Animator Animator;
    private EnemyManager enemyManager;

    

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyManager = GetComponent<EnemyManager>();
        Animator = GetComponent<Animator>();
    }

        public void TakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        Animator.SetTrigger("Hurt");
        if (enemyCurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Animator.SetTrigger("Death");
        enemyManager.moveSpeed = 0;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1f);
    }
}
