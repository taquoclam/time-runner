using UnityEngine;

public class EnemyController : MonoBehaviour
{

	private SoundManager mySoundManager;

    // Use this for initialization
    void Awake()
    {
		mySoundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        var tag = coll.gameObject.tag.ToLower();

        // die from projectile (todo: health, death animation)
        if (tag.StartsWith("playerprojectile"))
        {
			die ();
        }
    }

	public void die(){
		mySoundManager.levelOneDied ();
		Destroy (gameObject);
	}
}