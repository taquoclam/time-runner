using UnityEngine;

namespace Projectiles
{
    public class Axe : PlayerProjectile
    {
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 10.0f;
            
            // spin
            rb.angularVelocity = -720f;
        }
    }
}