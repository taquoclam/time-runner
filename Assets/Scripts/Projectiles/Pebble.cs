using UnityEngine;

namespace Projectiles
{
    public class Pebble : PlayerProjectile
    {
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 12.0f;
        }
    }
}