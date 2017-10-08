using UnityEngine;

public abstract class EnemiesWeapons : MonoBehaviour {

    // Use this for initialization
    public abstract void Attack();

    void Update()
    {
        // move weapon to player

        Type3[] shooters = FindObjectsOfType(typeof(Type3)) as Type3[];
        foreach (Type3 shooter in shooters)
        {
            Rigidbody2D enemy = shooter.GetComponent<Rigidbody2D>();
            transform.position = enemy.transform.position;
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
