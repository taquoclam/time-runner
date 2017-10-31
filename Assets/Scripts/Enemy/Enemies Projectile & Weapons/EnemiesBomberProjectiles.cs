using UnityEngine;

namespace Projectiles
{
    public class EnemiesBomberProjectiles : EnemiesProjectiles
    {
        public float force = 5.0f;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(GameControl.scrollSpeed, -force);
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {

            var tag = coll.gameObject.tag.ToLower();

            // die from projectile (todo: health, death animation)
            if (tag.StartsWith("playerprojectile") || tag.StartsWith("player") || tag.StartsWith("ground"))
                DestroySelf();
        }
    }
}