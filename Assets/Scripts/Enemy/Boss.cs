using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D body;
    public bool[] setAbi;
    private string evilType; // name of Enemy 
    public float timel;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timel)
        {
            enabled = true;
        }
    }
}