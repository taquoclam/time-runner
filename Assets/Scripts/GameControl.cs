using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public static float scrollSpeed = -5f;
    public static Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>();

    // Init
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

        // Load all weapons (only load them the first time)
        if (Weapons.Count == 0)
        {
            var weps = Resources.LoadAll("Prefabs/Weapons", typeof(GameObject)).Cast<GameObject>();
            foreach (GameObject wep in weps)
            {
                Weapon weapon = wep.GetComponent<Weapon>();
                Assert.NotNull(weapon, wep.name + " has no corresponding Weapon script");
                Weapons.Add(wep.name, wep.GetComponent<Weapon>());
            }
            Assert.IsNotEmpty(Weapons);            
        }
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
            // sanity check, runs once
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