using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // executed when player tries to attack
    public abstract void Attack();

    void Update()
    {
        // move weapon to player
        transform.position = PlayerController.Player.transform.position;
    }
}