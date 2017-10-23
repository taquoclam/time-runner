using UnityEngine;

namespace Projectiles
{
    public class EnemiesRockPro: EnemiesProjectiles
    {
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float x = player.transform.position.x - transform.position.x;
            float y = player.transform.position.y - transform.position.y;
            rb.velocity = new Vector2(x, y) * 1f;
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {

            var tag = coll.gameObject.tag.ToLower();

            // die from projectile (todo: health, death animation)
            if (tag.StartsWith("playerprojectile") || tag.StartsWith("player"))
                Destroy(gameObject);
        }
    }
}