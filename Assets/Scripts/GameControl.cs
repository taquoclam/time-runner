using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public float scrollSpeed = -1.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}