using UnityEngine;

public class EnemyController : MonoBehaviour
{

	private SoundManager mySoundManager;
	private ScoreManager myScoreManager;

    // Use this for initialization
    void Awake()
    {
		mySoundManager = FindObjectOfType<SoundManager>();
		myScoreManager = FindObjectOfType<ScoreManager>();
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
			myScoreManager.addScore (4);
			die ();
        }
    }

	public void die(){
		mySoundManager.levelOneDied ();
		Destroy (gameObject);
	}
}