using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int hp = 500;

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Projectile")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        hp -= 10;
    }
}
