using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

public class GameControl : MonoBehaviour
{
    // todo: Move this to some kind of separate LevelControl class, maybe separate LevelControl for each level
    public GameObject boss;

    public static GameControl instance;
    public static float scrollSpeed = -5f;
    private static float bossSpawnTime = 10f;
    public static Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>();
    public Canvas pauseMenu;
    private STATE state;

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
                Assert.IsNotNull(weapon, wep.name + " has no corresponding Weapon script");
                Weapons.Add(wep.name, wep.GetComponent<Weapon>());
            }
            Assert.IsTrue(Weapons.Count > 0);
        }

        // Spawn boss at appropriate time
        Invoke("SpawnBoss", bossSpawnTime);
    }

    // TODO: Make this actually work!
    void DisableSpawners()
    {
        foreach (var spawner in FindObjectsOfType<Spawner>())
        {
            spawner.DisableSelf();
        }
        foreach (var spawner in FindObjectsOfType<EnimesSpawners>())
        {
            spawner.DisableSelf();
        }
    }

    public void SpawnBoss()
    {
        DisableSpawners();
        Invoke("SpawnBossNow", 2);
    }

    void SpawnBossNow()
    {
        var maxX = getMaxX();
        var spawnLocation = new Vector3(maxX + this.boss.GetComponent<SpriteRenderer>().bounds.size.x / 2, -2f, 0);
        GameObject boss = Instantiate(this.boss, spawnLocation, Quaternion.identity);
    }

    // get largest visible x coordinate
    public static float getMaxX()
    {
        // create a temporary plane parallel to the background
        Plane zPlane = new Plane(Vector3.forward, Vector3.zero);

        // Shoot ray from camera to top-right side of screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        float distance;

        // get the hit point
        if (zPlane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance).x;
        }
        Debug.LogError("Boss ray didn't hit plane!");
        return 0;
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
            Assert.IsTrue(Background != -1);
            Assert.IsTrue(Ground != -1);
            Assert.IsTrue(Player != -1);
            Assert.IsTrue(Enemies != -1);
        }
    }

    // Use this for initialization
    void Start()
    {
        state = STATE.PLAY;
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Press escape to pause a game
        if (Input.GetKeyUp("p"))
        {
            SetUpPauseMenu();
        }
    }

    // Awake pause menu 
    public void SetUpPauseMenu()
    {
        if (state == STATE.PLAY)
        {
            state = STATE.PAUSE;
            pauseMenu.enabled = true;
            Time.timeScale = 0.00f;
        }
        else if (state == STATE.PAUSE)
        {
            state = STATE.PLAY;
            pauseMenu.enabled = false;
            Time.timeScale = 1.00f;
        }
    }

    // return state of game
    public STATE getGameState()
    {
        return state;
    }

    // quit application
    public void exit()
    {
        Application.Quit();
    }
}