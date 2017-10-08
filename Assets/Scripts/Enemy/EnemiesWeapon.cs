using UnityEngine;

public abstract class EnemiesWeapon : MonoBehaviour {

    // Use this for initialization
    public abstract void Attack();

    void Update()
    {
        // move weapon to player
        GameObject enemy = GameObject.Find("Type3");
        if (enemy != null)
            transform.position = enemy.transform.position;
    }
}
