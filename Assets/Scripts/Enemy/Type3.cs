using UnityEngine;

public class Type3 : MonoBehaviour
{
    public float shootRate;
    private bool isGrounded = false;
    public EnemiesWeapon weapon;
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
            Destroy(gameObject);
        }
    }
    void Fire1()
    {
        weapon.Attack();
    }

    // equip weapon
    void Equip(EnemiesWeapon weapon)
    {
        if (this.weapon != null)
        {
            this.weapon.enabled = false;
        }

        weapon.enabled = true;
        this.weapon = weapon;
    }
}