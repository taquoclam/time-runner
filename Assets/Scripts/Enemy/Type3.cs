using UnityEngine;

public class Type3 : MonoBehaviour
{
    private bool isGrounded = false;
    public EnemiesWeapons weapon;
    private EnemiesWeapons clone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null)
            Fire1();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag.ToLower();
        if (tag.StartsWith("ground"))
        {
            isGrounded = true;
        }
        if (tag.StartsWith("player") || tag.StartsWith("playerprojectile"))
        {
            if (gameObject != null)
                Destroy(gameObject);
            if (clone != null)
                clone.DestroySelf();
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
            if (clone != null)     
                clone.DestroySelf();
        }
    }
    void Fire1()
    {
        weapon.Attack();
    }
}