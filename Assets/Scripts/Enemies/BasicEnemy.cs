using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField]
    private float ChaseSpeed;
    [SerializeField]
    private int Damage = 10;

    public override void Attack()
    {
        // nothing to do here
    }

    public override void Move()
    {
        if (FindObjectOfType<PlayerMovement>() != null)
        {
            Vector3 direction = Vector3.Normalize(FindObjectOfType<PlayerMovement>().transform.position - transform.position);
            transform.position += direction * ChaseSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(Damage);
        }
    }
}
