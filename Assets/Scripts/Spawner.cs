using UnityEngine;

public class Spawner : MonoBehaviour
{
    // set in unity editor
    public GameObject toSpawn; // item to spawn

    public float spawnRate; // percentage chance to spawn an item when possible
    public float spawnPosition; // position to spawn item at (quick workaround; currently only works for spikes)
    public int maxInARow; // maximum # of items in a row
    public float minimumSpace; // min. space between sets of items

    private int inARow = 0; // items spawned in a row
    private float width; // width of item
    private float spawnRateMs; // spawnRate converted to ms
    private float minimumSpaceMs; // minimumSpace converted to ms

    void Start()
    {
        width = toSpawn.GetComponent<BoxCollider2D>().size.x;
        spawnRateMs = Mathf.Abs(width / GameControl.scrollSpeed);
        minimumSpaceMs = Mathf.Abs(minimumSpace / GameControl.scrollSpeed);

        // spawn whilst preventing overlap
        Invoke("Spawn", Mathf.Abs(width / GameControl.scrollSpeed));
    }

    void Update()
    {
    }

    void Spawn()
    {
        if ((spawnRate == 1 || spawnRate >= Random.value) && inARow < maxInARow)
        {
            Instantiate(toSpawn, new Vector3(transform.position.x, spawnPosition, transform.position.z),
                Quaternion.identity);
            inARow++;
            Invoke("Spawn", spawnRateMs);
        }
        else
        {
            inARow = 0;
            Invoke("Spawn", minimumSpaceMs);
        }
    }
    public void DisableSelf()
    {
        gameObject.SetActiveRecursively(false);
        this.enabled = false;
        CancelInvoke();
    }
}