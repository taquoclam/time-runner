using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject boss;
    public float waitTime = 5f;
    public int life = 10;
    private Rigidbody2D body;
    private bool isSpwaned = false;
    // Use this for initialization
    void Start()
    {
        body = GetComponent< Rigidbody2D > ();

        StartCoroutine(LateCall());
    }
    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(waitTime);
        if (!isSpwaned)
        {
            Instantiate(boss,
                    new Vector3(transform.position.x, transform.position.y, 0),
                    Quaternion.identity);
            isSpwaned = true;
        }
    }
     // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        var tag = coll.gameObject.tag.ToLower();
        print("im back");
        // die from projectile (todo: health, death animation)
        if (tag.StartsWith("playerprojectile"))
        {
            if (life < 1)
            {
                Destroy(gameObject);
            }
            else { life = life - 1; }
        }
    }
}