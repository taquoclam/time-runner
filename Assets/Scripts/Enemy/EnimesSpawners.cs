using UnityEngine;

public class EnimesSpawners : MonoBehaviour
{
    // each varibles using array must have matching size
    public GameObject[] spawners; // Spawner objects 

    public float[] spawnPosition; // spawners' position
    public float[] spawnRate; // spawners' spawn rate
    public float[] spawnersScore; // spawners' score after destroyed

    public float[] minimumSpace;

    private float[] width; // spawner's width after each iteration
    private float[] minimumSpaceMS;
    private float[] spawnRateMS;
    private int enemiesCount = 0; // number of enemy in a scroll
    public int maxEnemy; // max number of enemy in a scroll
    private GameObject[] currentEnemy;

    void Start()
    {
        currentEnemy = new GameObject[maxEnemy];
        width = new float[spawners.Length];
        minimumSpaceMS = new float[spawners.Length];
        spawnRateMS = new float[spawners.Length];
        for (int i = 0; i < spawners.Length; i++)
        {
            width[i] = spawners[i].GetComponent<BoxCollider2D>().size.x;
            spawnRateMS[i] = Mathf.Abs(spawnRate[i] / GameControl.scrollSpeed);
            minimumSpaceMS[i] = Mathf.Abs(minimumSpace[i] / GameControl.scrollSpeed);
            Invoke("Spawn", Mathf.Abs(width[i] / GameControl.scrollSpeed));
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void Spawn()
    {
        int randomEnemy = Random.Range(0, spawners.Length);
        if ((spawnRateMS[randomEnemy] == 1 || spawnRateMS[randomEnemy] >= Random.value) && enemiesCount < maxEnemy)
        {
            currentEnemy[enemiesCount] = Instantiate(spawners[randomEnemy],
                new Vector3(transform.position.x, spawnPosition[randomEnemy], transform.position.z),
                Quaternion.identity);
            enemiesCount++;
            Invoke("Spawn", spawnRateMS[randomEnemy]);
        }
        else
        {
            enemiesCount = 0;
            Invoke("Spawn", minimumSpaceMS[randomEnemy]);
        }
    }
    public void DisableSelf()
    {
        gameObject.SetActive(false);
        this.enabled = false;
        CancelInvoke();
    }
}