using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Collider2D coll;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        var name = coll.gameObject.name.ToLower();
        var tag = coll.gameObject.tag.ToLower();

        // die from projectile (todo: health, death animation)
        if (tag.StartsWith("playerprojectile"))
        {
            Destroy(gameObject);
        }
    }
}