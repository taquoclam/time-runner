using UnityEngine;

namespace Projectiles
{
    // A projectile shot by the player
    public class PlayerProjectile : MonoBehaviour
    {
        protected Rigidbody2D rb;
        public double Damage;

        // default: go at speed 1 in direction of mouse
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 5.0f;
        }

        void OnTriggerEnter2D(Collider2D coll)
        {

            var tag = coll.gameObject.tag.ToLower();

            if (tag.StartsWith("enemy"))
            {
                EnemyController ec = coll.GetComponent<EnemyController>();
                if (ec != null)
                    ec.TakeDamage(Damage);
                DestroySelf();
            } else if (tag.StartsWith("boss"))
            {
                BossController bc = coll.GetComponent<BossController>();
                if (bc != null)
                    bc.TakeDamage(Damage);
                DestroySelf();
            }
        }

        // todo: breaking animation
        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}