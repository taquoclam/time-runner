﻿using UnityEngine;

public class Type3 : MonoBehaviour
{
    private bool isGrounded = false;
    public EnemiesWeapons weapon;
    private EnemiesWeapons clone;
	public AudioSource deathSound;

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
        if (col.gameObject.tag.ToLower().StartsWith("ground"))
        {
            isGrounded = true;
        }
        if (col.gameObject.tag.ToLower().StartsWith("player"))
        {
            clone.DestroySelf();
			deathSound.Play ();
            Destroy(gameObject);
        }
    }
    void Fire1()
    {
        weapon.Attack();
    }
}