using UnityEngine;

namespace Projectiles
{
    public class Axe : PlayerProjectile
    {
        void Start()
        {
            Damage = 2.5;
            
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = PlayerController.DirectionOfMouse() * 10.0f;
            
            // spin
            rb.angularVelocity = -720f;
        }
    }
}