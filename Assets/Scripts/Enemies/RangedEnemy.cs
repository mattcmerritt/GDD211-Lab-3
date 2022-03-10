using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField]
    private float RetreatSpeed;
    [SerializeField]
    private int MeleeDamage = 5;
    [SerializeField]
    private GameObject ArrowPrefab;

    private float ShotDelay = 2f;
    private float Cooldown = 2f;

    public override void Attack()
    {
        if (FindObjectOfType<PlayerMovement>() != null)
        {
            if (Cooldown <= 0f) 
            { 
                GameObject.Instantiate(ArrowPrefab, transform.position + (FindObjectOfType<PlayerMovement>().transform.position - transform.position).normalized/2, Quaternion.identity).GetComponent<EnemyArrow>().SetDirection((FindObjectOfType<PlayerMovement>().transform.position - transform.position).normalized);
                Cooldown = ShotDelay;
            }
            else
            {
                Cooldown -= Time.deltaTime;
            }
        }
    }

    public override void Move()
    {
        if (FindObjectOfType<PlayerMovement>() != null)
        {
            Vector3 direction = -Vector3.Normalize(FindObjectOfType<PlayerMovement>().transform.position - transform.position);
            transform.position += direction * RetreatSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(MeleeDamage);
        }
    }
}
