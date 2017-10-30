using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public class EnemiesProjectiles : MonoBehaviour
    {
        protected Rigidbody2D rb;

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