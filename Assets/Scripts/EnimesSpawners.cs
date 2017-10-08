using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimesSpawners : MonoBehaviour {

    // each varibles using array must have matching size
    public GameObject[] spawners; // Spawner objects 
    public float[] spawnPosition;  // spawners' position
    public float[] spawnRate;  // spawners' spawn rate
    public float[] spawnersScore; // spawners' score after destroyed
    public string[] spawnerAbility; //Spawner's ability: ei. "s:10": shooter + spread, "j:70": jumper+ high, "10": normal + position, "x:10": splasher + speed
    public float[] minimumSpace;
    public float[] enemyHP;
    public GameObject boss;
    public string summonCondition; // conditions to summon a boss
    public string bossAbility;

    private float[] width; // spawner's width after each iteration
    private float[] minimumSpaceMS;
    private float[] spawnRateMS;
    private int enemiesCount=0; // number of enemy in a scroll
    public int maxEnemy; // max number of enemy in a scroll
    private GameObject[] currentEnemy;
	void Start () {
        currentEnemy = new GameObject[maxEnemy];
        width = new float[spawners.Length];
        minimumSpaceMS = new float[spawners.Length];
        spawnRateMS = new float[spawners.Length];
        for (int i=0; i< spawners.Length; i++)
        {
            width[i] = spawners[i].GetComponent<BoxCollider2D>().size.x;
            print(width[i]);
            spawnRateMS[i] = Mathf.Abs(spawnRate[i] / GameControl.instance.scrollSpeed);
            minimumSpaceMS[i] = Mathf.Abs(minimumSpace[i] / GameControl.instance.scrollSpeed);
            Invoke("Spawn", Mathf.Abs(width[i] / GameControl.instance.scrollSpeed));
        }
        

    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < enemiesCount + 1; i++)
        {
            Rigidbody2D current = currentEnemy[i].GetComponent<Rigidbody2D>();
            if (currentEnemy[i].name.StartsWith("jumper")){
                current.velocity = new Vector2(0, -3);
            }
        }
    }
    void Spawn()
    {
        int randomEnemy = Random.Range(1, maxEnemy);
        if (spawnRateMS[randomEnemy] >= Random.Range(0.0001f, 1f) && enemiesCount < maxEnemy)
        {
            currentEnemy[enemiesCount] = Instantiate(spawners[randomEnemy], new Vector3(transform.position.x, spawnPosition[randomEnemy], transform.position.z), Quaternion.identity);
            enemiesCount++;
            Invoke("Spawn", spawnRateMS[randomEnemy]);
        }
        else {
            enemiesCount = 0;
            Invoke("Spawn", minimumSpaceMS[randomEnemy]);
        }
    }
}
