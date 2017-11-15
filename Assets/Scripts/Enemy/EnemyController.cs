using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public double hp = 1;

    private SoundManager mySoundManager;
    private ScoreManager myScoreManager;
    private float itemSpawnRate = 0.25f;

    // ensure we die & drop item only once
    private Object deathLock = new Object();

    private bool dead = false;

    // Use this for initialization
    void Awake()
    {
        mySoundManager = FindObjectOfType<SoundManager>();
        myScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(double damage)
    {
        hp -= damage;
        if (hp <= 0) die();
    }

    public void die()
    {
        lock (deathLock)
        {
            if (dead) return;
            dead = true;
        }

        mySoundManager.levelOneDied();
        myScoreManager.addScore(4);
        if (itemSpawnRate == 1 || itemSpawnRate > Random.value)
        {
            spawnRandomItem();
        }
        Destroy(gameObject);
    }

    private void spawnRandomItem()
    {
        Instantiate(Util.RandomInDict(GameControl.Weapons), transform.position, Quaternion.identity);
    }
}