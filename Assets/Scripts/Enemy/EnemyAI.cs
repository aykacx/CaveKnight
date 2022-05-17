using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private float AttackRange;
    [SerializeField]
    private int sightRange;
    [SerializeField] 
    private Transform enemyWatchPoint;


    private Transform target;
    public float followSpeed;
    private float oldPosition;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 20;
    [SerializeField] float attackRate = 2f;
    float nextAttackTime = 0f;



    void Start()
    {
        animator = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        EnemyAi();
    }
    #region Functions
    private void EnemyMove()
    {
        Vector3 guardPosition = new Vector3(enemyWatchPoint.position.x, gameObject.transform.position.y, enemyWatchPoint.position.x);
        transform.position = Vector2.MoveTowards(transform.position, guardPosition, followSpeed * Time.deltaTime);

        if (transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        oldPosition = transform.position.x;
        if (transform.position.x == enemyWatchPoint.position.x)
        {
            animator.SetFloat("Speed", 0);
        }
    }
    
    public void EnemyAi()
    {
        if (Vector2.Distance(target.transform.position, gameObject.transform.position) <= sightRange & Vector2.Distance(target.transform.position, gameObject.transform.position) > AttackRange)
        {
            EnemyFollow();
        }
        if (Vector2.Distance(target.transform.position, gameObject.transform.position) <= AttackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if(Vector2.Distance(target.transform.position, gameObject.transform.position) >= sightRange)
        {
            EnemyMove();
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

    void EnemyFollow()
    {
        animator.SetFloat("Speed", 1);
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        if (transform.position.x > oldPosition)
        {
           
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        oldPosition = transform.position.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
        if (collision != null)
        {
            EnemyMove();
        }
        
    }
    #endregion
}
