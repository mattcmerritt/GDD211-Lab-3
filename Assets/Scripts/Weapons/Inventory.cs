using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Components
    [SerializeField]
    private Animator ani;

    // Rotation data
    private int Direction;

    // Instance data
    private Weapon ActiveWeapon;
    [SerializeField]
    private Sword Sword;
    [SerializeField]
    private Bow Bow;
    [SerializeField]
    private Wand Wand;

    private void Start()
    {
        ActiveWeapon = Sword;
        ani.SetBool("HasSword", true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveWeapon = Sword;
            ani.SetBool("HasSword", true);
            ActiveWeapon.UpdateSprite(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveWeapon = Bow;
            ani.SetBool("HasSword", false);
            ActiveWeapon.UpdateSprite(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveWeapon = Wand;
            ani.SetBool("HasSword", false);
            ActiveWeapon.UpdateSprite(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveWeapon.UseWeapon(gameObject);
        }
    }

    public void SetDirection(int direction)
    {
        Direction = direction;
        ani.SetFloat("Direction", direction);
    }

    public Vector3 GetDirectionAsVector()
    {
        if (Direction == 0)
        {
            return Vector3.right;
        }
        else if (Direction == 1)
        {
            return Vector3.up;
        }
        else if (Direction == 2)
        {
            return Vector3.left;
        }
        else 
        {
            return Vector3.down;
        }
    }

    // this was necessary because the collision detection for the sword was done here
    // 
    public bool HasSword()
    {
        return ActiveWeapon == Sword;
    }
}
