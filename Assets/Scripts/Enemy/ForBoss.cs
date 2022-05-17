using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBoss : MonoBehaviour
{
    [SerializeField]
    private int BossMaxHealth;
    private int BossCurrentHealth;

    private Animator Animator;
    private EnemyAI enemyai;

    void Start()
    {
        BossCurrentHealth = BossMaxHealth;
        enemyai = GetComponent<EnemyAI>();
        Animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        BossCurrentHealth -= damage;
        Animator.SetTrigger("Hurt");
        if (BossCurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Animator.SetBool("isDead", true);
        enemyai.followSpeed = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject, 0.7f);
    }
}
