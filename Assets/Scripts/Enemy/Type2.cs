using UnityEngine;

public class Type2 : MonoBehaviour
{
    public float speed;
    private bool isGrounded = false;
    private Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            body.velocity = new Vector2(-speed, 0);
        }
    }

    // On condition that collide with objescts
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag.ToLower();
        // Is touching ground
        if (tag.StartsWith("ground"))
        {
            isGrounded = true;
        }

        // Attacked by players
        if (tag.StartsWith("player") || tag.StartsWith("enemy"))
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
    }
}