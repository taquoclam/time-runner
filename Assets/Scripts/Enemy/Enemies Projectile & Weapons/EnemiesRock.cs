using System;
using System.Diagnostics;
using UnityEngine;

namespace EnemiesWp
{
    public class EnemiesRock : EnemiesWeapons
    {
        public GameObject projectile;
        private Rigidbody2D body;
        private TimeSpan useDelay = new TimeSpan((long)(TimeSpan.TicksPerSecond * 1.5));
        private Stopwatch stopwatch = new Stopwatch();

        // attack if enough time has passed
        public override void Attack()
        {
            if (stopwatch.Elapsed > useDelay || !stopwatch.IsRunning)
            {
                AttackNow();
                stopwatch.Reset();
                stopwatch.Start();
            }
        }

        private void AttackNow()
        {
            Type3[] shooters = FindObjectsOfType(typeof(Type3)) as Type3[];
            foreach (Type3 shooter in shooters)
            {
                if (shooter != null)
                {
                    Instantiate(projectile, shooter.transform.position, Quaternion.identity);
                }
            }
            
        }
        public void DestroySelf()
        {
            Destroy(this);
        }
    }
}