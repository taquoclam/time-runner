using UnityEngine;

public class Type3 : MonoBehaviour
{
    public float shootRate;
    private bool isGrounded = false;
    public GameObject weapon;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.time;
        if (isGrounded)
        {
            GameObject bullet = Instantiate(weapon,
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            body.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            shootRate += Time.time;
            isGrounded = false;
        }
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