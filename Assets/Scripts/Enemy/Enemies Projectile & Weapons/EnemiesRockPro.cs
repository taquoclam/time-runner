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
    }
}