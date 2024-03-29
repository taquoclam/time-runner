﻿using UnityEngine;

public class Type1 : MonoBehaviour
{
    public float height;
    public float jumpTime;
    private bool isGrounded = false;
    private Rigidbody2D body;
    private float startTime = 0;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Time.time > startTime)
        {
            body.AddForce(new Vector2(0, height * 64));
            isGrounded = false;
            startTime = Time.time + jumpTime;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag.ToLower();
        if (tag.StartsWith("ground"))
        {
            isGrounded = true;
        }
    }
}