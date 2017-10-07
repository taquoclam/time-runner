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
            body.AddForce(new Vector2(-speed, 0));
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