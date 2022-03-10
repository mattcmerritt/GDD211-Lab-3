using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bow : Weapon
{
    [SerializeField]
    private GameObject ArrowPrefab;

    [SerializeField]
    private GameObject FirePoint;

    public override void UseWeapon(GameObject inventory)
    {
        base.UseWeapon(inventory);
        GameObject.Instantiate(ArrowPrefab, FirePoint.transform.position, Quaternion.identity).GetComponent<Arrow>().SetDirection(inventory.GetComponent<Inventory>().GetDirectionAsVector());
    }
}
