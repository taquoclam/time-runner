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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float x = player.transform.position.x - transform.position.x;
            float y = player.transform.position.y - transform.position.y;
            rb.velocity = new Vector2(x, y) * 1.0f;
        }

        void OnTriggerEnter2D(Collider2D coll)
        {

            var tag = coll.gameObject.tag.ToLower();
            if (tag.StartsWith("Player"))
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