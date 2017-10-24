using UnityEngine;

namespace Projectiles
{
    public class Arrow : PlayerProjectile
    {
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            var mouseDirection = PlayerController.DirectionOfMouse();
            rb.velocity = mouseDirection * 15.0f;
            
            // turn towards mouse
            var zRotation = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        }
    }
}