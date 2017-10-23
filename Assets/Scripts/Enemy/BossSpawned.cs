using UnityEngine;
using UnityEngine.SceneManagement;
public class BossSpawned : MonoBehaviour {
    private bool isDead = false;
    public int life = 100;
	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        var tag = coll.gameObject.tag.ToLower();
        // die from projectile (todo: health, death animation)
        if (tag.StartsWith("playerprojectile"))
        {
            if (life < 1)
            {
                Destroy(gameObject);
                isDead = true;
                SceneManager.LoadScene("End");
            }
            else { life = life - 1; }
        }
    }
    public bool IsDead()
    {
        return isDead;
    }
}
