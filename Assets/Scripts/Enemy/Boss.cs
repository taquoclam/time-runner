using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject boss;
    public float waitTime = 5f;
    void Start()
    {
        StartCoroutine(LateCall());
        StopCoroutine(LateCall());
    }
    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(waitTime);

        Instantiate(boss,
                new Vector3(transform.position.x, transform.position.y, 0),
                Quaternion.identity);
    }
     // Update is called once per frame

}