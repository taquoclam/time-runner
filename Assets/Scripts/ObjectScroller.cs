﻿using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}