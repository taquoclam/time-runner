using UnityEngine;

public abstract class EnemiesWeapons : MonoBehaviour {

    // Use this for initialization
    public abstract void Attack();

    void Update()
    {
        // move weapon to player
        Rigidbody2D enemies = gameObject.GetComponent<Rigidbody2D>();

        Type3[] shooters = FindObjectsOfType(typeof(Type3)) as Type3[];
        Type4[] bombers = FindObjectsOfType(typeof(Type4)) as Type4[];
        foreach (Type3 shooter in shooters)
        {
            Rigidbody2D enemy = shooter.GetComponent<Rigidbody2D>();
            transform.position = enemy.transform.position;
        }
        foreach (Type4 bomber in bombers)
        {
            Rigidbody2D enemy = bomber.GetComponent<Rigidbody2D>();
            transform.position = enemy.transform.position;
        }
    }
    public void DestroySelf()
    {
        if (gameObject != null)
            Destroy(gameObject);
    }
}
