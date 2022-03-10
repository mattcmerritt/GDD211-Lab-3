using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile, IDamageDealing
{
    private Enemy Target;

    protected override void Start()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Enemy closest = null;
        float distance = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            if (Vector3.Distance(transform.position, e.transform.position) < distance)
            {
                closest = e;
                distance = Vector3.Distance(transform.position, e.transform.position);
            }
        }

        Target = closest;
    }

    public override void Move(float speed)
    {
        if (Target == null)
        {
            base.Move(speed);
        }
        else
        {
            Direction = Vector3.Normalize(Target.transform.position - transform.position);
            transform.position += Direction * Speed * Time.deltaTime;
        }
    }

    public int GetDamage()
    {
        return 25;
    }
}
