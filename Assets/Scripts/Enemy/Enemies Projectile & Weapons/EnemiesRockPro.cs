using UnityEngine;

namespace Projectiles
{
    public class EnemiesRockPro: EnemiesProjectiles
    {
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionFrom(transform.position) * 5.0f - new Vector2(5.0f, 0);
            Debug.LogFormat("Speed is {0} but should be 8*{1}", rb.velocity, PlayerController.DirectionFrom(transform.position));
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