using UnityEngine;

public class Type3 : MonoBehaviour
{
    public float speedRate;
    private bool isGrounded = false;
    private Rigidbody2D body;
    private GameObject weapon;
    public string weaponName;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        weapon = Instantiate(weapon,
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.ToLower().StartsWith("ground"))
        {
            isGrounded = true;
        }
        if (col.gameObject.tag.ToLower().StartsWith("player") || col.gameObject.tag.ToLower().StartsWith("enemy"))
        {
            Destroy(gameObject);
        }
    }
}