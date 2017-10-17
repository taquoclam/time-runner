using UnityEngine;

public class Type3 : MonoBehaviour
{
    private bool isGrounded = false;
    public EnemiesWeapons weapon;
    private EnemiesWeapons clone;
    // Use this for initialization
    void Start()
    {
        Equip(weapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null)
            Fire1();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.ToLower().StartsWith("ground"))
        {
            isGrounded = true;
        }
        if (col.gameObject.tag.ToLower().StartsWith("player") || col.gameObject.tag.ToLower().StartsWith("enemy"))
        {
            clone.DestroySelf();
            Destroy(gameObject);
        }
    }
    void Fire1()
    {
        weapon.Attack();
    }

    // equip weapon
    void Equip(EnemiesWeapons weapon)
    {
        clone = Instantiate(weapon, transform.position, Quaternion.identity);
    }
}