using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.VR.WSA;
using Projectiles;
public class BossController : MonoBehaviour {
    public int life = 100;
    // ensure we die only once
    private Object deathLock = new Object();
    private bool dead = false;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool enteringScreen;
    public EnemiesShooterProjectile weapon;
    public float shootingRate;
    public float jumpTime;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(GameControl.scrollSpeed, 0);

        enteringScreen = true;
        if (weapon != null)
            InvokeRepeating("Fire", 0.0f, shootingRate);
        //InvokeRepeating("Jump", 10.0f, jumpTime);
    }

    void Update()
    {
        // if already entered screen, stop entering
        if (enteringScreen && (GameControl.getMaxX() > transform.position.x + sr.bounds.size.x/2))
        {
            enteringScreen = false;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        var tag = coll.gameObject.tag.ToLower();
        if (tag.StartsWith("playerprojectile"))
        {
            if (life < 1)
            {
                die();
            }
            else { life -= 1; }
        }
    }

    public void die()
    {
        lock (deathLock)
        {
            if (dead)
            {
                return;
            }
            dead = true;
        }

        Destroy(gameObject);
        // todo: dim screen or something
        SceneManager.LoadScene("End");
    }

    public void Fire()
    {
        Instantiate(weapon, transform.position, Quaternion.identity);
    }


    //todo: Fix with time jump back to position again 
    public void Jump()
    {
        rb.velocity = new Vector2(0.0f, 5.0f);
    }
}