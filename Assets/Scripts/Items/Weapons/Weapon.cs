using Items;
using UnityEngine;

public abstract class Weapon : Item
{
    // executed when player tries to attack
    public abstract void Attack();

    public override Type GetType()
    {
        return Type.Weapon;
    }
}