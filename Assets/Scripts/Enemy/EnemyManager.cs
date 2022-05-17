using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Animator animator;
    private Transform target;


    public float moveSpeed;
    [SerializeField] Transform defaultPosition;


    [SerializeField] float sightRange;
    [SerializeField] float attackDistance;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] int attackDamage;
    [SerializeField] float attackRate;
    private  float  nextAttackTime = 0f;




    void Start()
    {
        animator = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameObject.transform.position = defaultPosition.position;
    }

    
    void Update()
    {
        EnemyAi();
    }
    void EnemyAi()
    {
        if (Vector2.Distance(target.position,transform.position) <= sightRange & Vector2.Distance(target.position,transform.position) > attackDistance)
        {
            FollowPlayer();
        }
        if (Vector2.Distance(target.position,transform.position) <= attackDistance)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
            animator.SetFloat("Speed", 0);
        }
        if (Vector2.Distance(target.position,gameObject.transform.position) > sightRange)
        {
            MoveToDefaultPos();
        }
    }

    public void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void FollowPlayer()
    {
        Vector2 targetPos = new Vector2(target.position.x, gameObject.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        animator.SetFloat("Speed", 1);
        if (transform.position.x < target.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x > target.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void MoveToDefaultPos()
    {
        if (transform.position.x < defaultPosition.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x > defaultPosition.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        Vector2 defaultPos = defaultPosition.position;
        transform.position = Vector2.MoveTowards(transform.position, defaultPos, moveSpeed * Time.deltaTime);
        animator.SetFloat("Speed", 1);
        if (transform.position == defaultPosition.position)
        {
            transform.rotation = defaultPosition.rotation;
            animator.SetFloat("Speed", 0);
        }
    }
}
