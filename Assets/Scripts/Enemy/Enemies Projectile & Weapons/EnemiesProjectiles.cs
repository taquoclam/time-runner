using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public class EnemiesProjectiles : MonoBehaviour
    {
        protected Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionFrom(transform.position) * 5.0f - new Vector2(5.0f, 0);
        }

        void OnTriggerEnter2D(Collider2D coll)
        {

            var tag = coll.gameObject.tag.ToLower();
            if (tag.StartsWith("Player") || tag.StartsWith("Playerprojectile"))
            {
                DestroySelf();
            }
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}