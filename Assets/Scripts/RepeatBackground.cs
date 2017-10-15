using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private BoxCollider2D collider;
    private float horizontalLength;
    private float startx;

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        horizontalLength = collider.size.x;
        startx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + horizontalLength < startx)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        transform.position += new Vector3(startx - transform.position.x, 0, 0);
    }
}