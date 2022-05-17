using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    Rigidbody2D rb2d;
    public float bulletSpeed;
    public float destroyTime;
    public GameObject bulletImpact;

    public void OnObjectSpawn()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(20);
        }
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<ForBoss>().TakeDamage(20);
        }
        if (collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("hitBox"))
        {
            return;
        }
        if (collision.CompareTag("bossHitBox"))
        {
            return;
        }
        if (collision = null)
        {
            return;
        }

        gameObject.SetActive(false);
        GameObject delete = Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(delete, 0.333f);
    }

}
