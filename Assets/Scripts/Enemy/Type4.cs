using UnityEngine;

public class Type4 : MonoBehaviour
{

    public EnemiesWeapons weapon;

    // Use this for initialization
    void Start()
    {
        if (weapon != null)
        {
            
            InvokeRepeating("Fire1", 0, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag.ToLower();
        if (tag.StartsWith("player") || tag.StartsWith("playerprojectile"))
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        var tag = coll.gameObject.tag.ToLower();

        // die from projectile (todo: health, death animation)
        if (tag.StartsWith("playerprojectile"))
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
    }
    void Fire1()
    {
        print("4 is shooting");
        Instantiate(weapon, transform.position, Quaternion.identity);
    }
}