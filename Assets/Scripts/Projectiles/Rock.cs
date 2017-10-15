using UnityEngine;

namespace Projectiles
{
    public class Rock : PlayerProjectile
    {
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 10.0f;
        }
    }
}