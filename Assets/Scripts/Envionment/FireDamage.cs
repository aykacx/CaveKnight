using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform burnPoint;
    [SerializeField] float burnRange = 0.5f;
    [SerializeField] int burnDamage;

    public void Burn()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(burnPoint.position, burnRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().TakeDamage(burnDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (burnPoint == null)
            return;
        Gizmos.DrawWireSphere(burnPoint.position, burnRange);
    }
}
