using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{

	private SoundManager mySoundManager;
	private ScoreManager myScoreManager;
	private float itemSpawnRate = 1f; // todo: not 1
	
	// ensure we die & drop item only once
	private Object deathLock = new Object();
	private bool dead = false;

    // Use this for initialization
    void Awake()
    {
		mySoundManager = FindObjectOfType<SoundManager>();
		myScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        var tag = coll.gameObject.tag.ToLower();

        // die from projectile (todo: health, death animation)
        if (tag.StartsWith("playerprojectile"))
        {
			myScoreManager.addScore (4);
			die ();
        }
    }

	public void die(){
		lock (deathLock)
		{
			if (dead)
			{
				return;
			}
			dead = true;
		}
		
		mySoundManager.levelOneDied ();
		if (itemSpawnRate == 1 || itemSpawnRate > Random.value)
		{
			spawnRandomItem();
		}
		Destroy (gameObject);
	}

	private void spawnRandomItem()
	{
		Instantiate(Util.RandomInDict(GameControl.Weapons), transform.position, Quaternion.identity);
	}
}