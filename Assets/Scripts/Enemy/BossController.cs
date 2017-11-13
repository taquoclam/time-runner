using System;
using Projectiles;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class BossController : MonoBehaviour
{
    public double hp = 100;
    private double startHp; // caches the HP boss starts with

    // ensure we die only once
    private Object deathLock = new Object();

    private bool dead = false;

    private Animator myAnim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool enteringScreen;
    public EnemiesShooterProjectile weapon;
    public float shootingRate;

    private Slider healthBar;

    public float jumpTime;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(GameControl.scrollSpeed, 0);

        healthBar = GameObject.Find("BossHealth").GetComponent<Slider>();

        healthBar.value = healthBar.maxValue;
        healthBar.GetComponent<CanvasGroup>().alpha = 1; // make it visible

        startHp = hp;

        enteringScreen = true;
        if (weapon != null)
            InvokeRepeating("Fire", 0.0f, shootingRate);
        //InvokeRepeating("Jump", 10.0f, jumpTime);
    }

    void Update()
    {
        // if already entered screen, stop entering
        if (enteringScreen && (GameControl.getMaxX() > transform.position.x + sr.bounds.size.x / 2))
        {
            enteringScreen = false;
            rb.velocity = Vector2.zero;
        }
    }

    // Take damage of this amount
    public void TakeDamage(double damage)
    {
        hp -= damage;
        healthBar.value = (float) (healthBar.maxValue * (Math.Max(hp, 0) / startHp));
        if (hp <= 0)
        {
            healthBar.GetComponent<CanvasGroup>().alpha = 0; // hide boss health bar
            die();
        }
        else
        {
            damageAnim();
        }
    }

    private void damageAnim()
    {
        myAnim.SetBool("damaged", true);
        Invoke("resetAnim", 0.3f);
    }

    private void resetAnim()
    {
        myAnim.SetBool("damaged", false);
    }

    private void die()
    {
        lock (deathLock)
        {
            if (dead) return;
            dead = true;
        }

        Destroy(gameObject);
        SceneManager.LoadScene("End");
    }

    private void Fire()
    {
        Instantiate(weapon, transform.position, Quaternion.identity);
    }


    //todo: Fix with time jump back to position again 
    public void Jump()
    {
        rb.velocity = new Vector2(0.0f, 5.0f);
    }
}