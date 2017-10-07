using UnityEngine;

public class Type1 : MonoBehaviour
{
    public float height;
    public float jumpTime;
    private bool isGrounded = false; 
    private Rigidbody2D body;
    private float startTime = 0;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.deltaTime;
        if (isGrounded)
        {
            body.velocity =  new Vector2(0, height);
            isGrounded = false;
            startTime = startTime + jumpTime;
            print("im");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        print("im not");
        if (col.gameObject.tag.ToLower() == "ground")
        {
            isGrounded = true;
        }
    }
}