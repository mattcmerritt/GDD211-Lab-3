using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon 
{
    public Sprite Sprite;

    public virtual void UseWeapon(GameObject inventory)
    {
        UpdateSprite(inventory); // in case it had not changed
    }

    public void UpdateSprite(GameObject inventory)
    {
        inventory.GetComponent<SpriteRenderer>().sprite = Sprite;
    }
}
