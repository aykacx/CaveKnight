using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Bulletpool.Instance.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
    }
}
