using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wand : Weapon
{
    [SerializeField]
    private GameObject FireballPrefab;

    [SerializeField]
    private GameObject FirePoint;

    public override void UseWeapon(GameObject inventory)
    {
        base.UseWeapon(inventory);
        GameObject.Instantiate(FireballPrefab, FirePoint.transform.position, Quaternion.identity).GetComponent<Fireball>().SetDirection(inventory.GetComponent<Inventory>().GetDirectionAsVector());
    }
}
