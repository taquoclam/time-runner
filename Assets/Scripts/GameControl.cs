using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public float scrollSpeed = -1.5f;


    void Awake()
    {
        // Instantiation
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        // Layer interaction
        Physics2D.IgnoreLayerCollision(Layers.Enemies, Layers.Enemies); // so enemies don't bump into each other
        Physics2D.IgnoreLayerCollision(Layers.Player, Layers.Player); // player & projectile
        Physics2D.IgnoreLayerCollision(Layers.Player, Layers.Enemies, false); // players and enemies collide
        
        // Half the volume since current sound effects are p loud
        AudioListener.volume = 0.5f;
    }

    // layer numbers
    public static class Layers
    {
        public static readonly int
            Background = LayerMask.NameToLayer("Background"),
            Ground = LayerMask.NameToLayer("Ground"),
            Player = LayerMask.NameToLayer("Player"),
            Enemies = LayerMask.NameToLayer("Enemies");

        static Layers()
        {
            // sanity check
            Assert.Greater(Background, -1);
            Assert.Greater(Ground, -1);
            Assert.Greater(Player, -1);
            Assert.Greater(Enemies, -1);
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}