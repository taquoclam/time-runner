using UnityEngine;

namespace Projectiles
{
    public class EnemiesProjectile: MonoBehaviour
    {
        protected Rigidbody2D rb;
        public float speedRate = 0.1f;
        // default: go at speed 1 in direction of mouse
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float x = (enemy.transform.position.x - player.transform.position.x) * speedRate;
       
            float x = (transform.position.x - player.transform.position.x) * speedRate;
            float y = (transform.position.x - player.transform.position.x) * speedRate;
            rb.velocity = new Vector2(x, y);
        }

        void OnTriggerEnter2D(Collider2D coll)
        {

            var tag = coll.gameObject.tag.ToLower();

            // break on enemy (todo: make breaking animation)
            if (tag.StartsWith("player"))
            {
                DestroySelf();
            }
        }

        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}