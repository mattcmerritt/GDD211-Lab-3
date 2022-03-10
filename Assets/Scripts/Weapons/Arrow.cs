using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile, IDamageDealing
{
    protected override void Start()
    {
        if (Direction == Vector3.right)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        else if (Direction == Vector3.up)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Direction == Vector3.left)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        else if (Direction == Vector3.down)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
    }

    public int GetDamage()
    {
        return 50;
    }
}
