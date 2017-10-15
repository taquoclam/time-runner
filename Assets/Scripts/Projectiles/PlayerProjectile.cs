using UnityEngine;

namespace Projectiles
{
    // A projectile shot by the player
    public class PlayerProjectile: MonoBehaviour
    {
        protected Rigidbody2D rb;
        
        // default: go at speed 1 in direction of mouse
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 5.0f;
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            string name = coll.gameObject.name.ToLower();
            string tag = coll.gameObject.tag.ToLower();

            // break on enemy (todo: make breaking animation)
            if (tag.StartsWith("enemy"))
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