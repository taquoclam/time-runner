using UnityEngine;

public class DestroyAfterSeen : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void OnBecameVisible()
    {
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}