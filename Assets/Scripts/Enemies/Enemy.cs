using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private int Health = 100;

    private void Update()
    {
        Move();
        Attack();
    }

    public abstract void Move();
    public abstract void Attack();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageDealing projectile = collision.GetComponent<IDamageDealing>();

        if (projectile != null)
        {
            Health -= projectile.GetDamage();
            Destroy(collision.gameObject);
        }
        // if weapon layer and the active weapon is sword, deal sword damage
        else if (collision.gameObject.layer == 6 && collision.GetComponent<Inventory>().HasSword()) 
        {
            Health -= Sword.GetDamage();
        }

        if (Health <= 0)
        {
            // count score
            Destroy(gameObject);
        }
    }
}
