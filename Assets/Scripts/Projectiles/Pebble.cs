using UnityEngine;

namespace Projectiles
{
    public class Pebble : PlayerProjectile
    {
        void Start()
        {
            Damage = 1;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 12.0f;
        }
    }
}