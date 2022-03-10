using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sword : Weapon
{
    public override void UseWeapon(GameObject inventory)
    {
        base.UseWeapon(inventory);
        inventory.GetComponent<Animator>().SetTrigger("Swing");
    }

    public static int GetDamage()
    {
        return 100;
    }
}
