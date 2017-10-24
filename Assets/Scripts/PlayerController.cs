using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

/**
 * ASSUME WE HAVE ONE PLAYER
 */
public class PlayerController : MonoBehaviour
{
    // assumes we have one player
    public static GameObject Player { get; private set; }

    public float moveSpeed;
    public float jumpSpeed;
    public Weapon defaultWeapon;
    private Rigidbody2D myRigidbody;
    private HeartControl myHeartControl;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;
    public ParticleSystem damageParticle;
    private Animator myAnim;

	public AudioSource jumpSound;
	public AudioSource deathSound;

    private bool jumpHeld = false;

    // inventory
    private Weapon weapon;

    // Use this for initialization
    void Start()
    {
        Player = gameObject;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myHeartControl = FindObjectOfType<HeartControl>();
        jumpSpeed = 9;

        Equip(defaultWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //variable jump height
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.AddForce(new Vector2(0, jumpSpeed * 64));
            jumpHeld = true;
			jumpSound.Play ();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpHeld = false;
        }

        if (!isGrounded && !jumpHeld)
        {
            myRigidbody.AddForce(new Vector2(0, -12));
        }

        // animations
        myAnim.SetBool("Grounded", isGrounded);

        if (myHeartControl.healthCount <= 0)
        {
            Die();
        }

        // shooting
        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
        {
            Fire1();
        }
    }

    // debug: log all items player collides with, only once
    HashSet<string> collidedWith = new HashSet<string>();

    void OnCollisionEnter2D(Collision2D coll)
    {
        // debug
        string name = coll.gameObject.name.ToLower();
        string tag = coll.gameObject.tag.ToLower();
        if (!collidedWith.Contains(name))
        {
            collidedWith.Add(name);
            Debug.LogFormat("{0} collided with '{1}' [{2}]", gameObject.name, name, tag);
        }
        
        // pick up items
        if (tag.StartsWith("item"))
        {
            Debug.LogFormat("Picking up {0}", coll.gameObject.name);
            PickUp(coll.gameObject);
        }
    }

    // debug: log all items player triggers, only once
    HashSet<string> triggered = new HashSet<string>();

    void OnTriggerEnter2D(Collider2D coll)
    {
        // debug
        string name = coll.gameObject.name.ToLower();
        if (!collidedWith.Contains(name))
        {
            collidedWith.Add(name);
            Debug.Log(gameObject.name + " triggered: " + name);
        }

        // die from spike
        if (name.StartsWith("normal"))
        {
            Damage();
        }

        // die from enemies
        string tag = coll.gameObject.tag.ToLower();
        if (tag.StartsWith("enemy") || tag.StartsWith("weapon"))
        {
            Damage();
        }
    }

    void PickUp(GameObject goItem)
    {
        Item item = goItem.GetComponent<Item>();
        Assert.IsNotNull(item, goItem.name + "'s tag starts with item but is not an item");

        switch (item.GetType())
        {
            case Item.Type.Weapon:
                Equip(goItem.GetComponent<Weapon>());
                break;
            default:
                Debug.LogErrorFormat("Unhandled item type {0}", item.GetType());
                break;
        }
        
        Destroy(goItem);
    }

    void Damage()
    {
        ParticleSystem particles =
            Instantiate(damageParticle, myRigidbody.transform.position, myRigidbody.transform.rotation);
        Destroy(particles, 1);
        myHeartControl.DamagePlayer(1);
    }

    void Die()
    {
		deathSound.Play ();
        Invoke("ResetScene", 1);
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Direction from player to point
    public static Vector2 DirectionTo(Vector2 point)
    {
        Vector2 direction = point - (Vector2) Player.transform.position;
        direction.Normalize();
        return direction;
    }

    // Direction from point to player
    public static Vector2 DirectionFrom(Vector2 point)
    {
        return -DirectionTo(point);
    }

    // Direction from player to mouse
    public static Vector2 DirectionOfMouse()
    {
        return DirectionTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    // Shoot.
    // Called on Fire1 input.
    void Fire1()
    {
        weapon.Attack();
    }

    // equip weapon
    void Equip(Weapon weapon)
    {
        if (this.weapon != null)
        {
            this.weapon.enabled = false;
        }

        weapon.enabled = true;
        this.weapon = weapon;
    }
}