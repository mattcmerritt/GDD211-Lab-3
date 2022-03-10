using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : Projectile
{
    protected override void Start()
    {
        transform.eulerAngles = new Vector3(0f, 0f, -Mathf.Atan2(Direction.x, Direction.y) * Mathf.Rad2Deg);
    }

    public int GetDamage()
    {
        return 20;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(GetDamage());
            Destroy(gameObject);
        }
    }
}
