using System;
using System.Diagnostics;
using UnityEngine;

namespace EnemiesWp
{
    public class EnemiesRockBomber : EnemiesWeapons
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
                print(1);
                AttackNow();
                stopwatch.Reset();
                stopwatch.Start();
            }
        }

        private void AttackNow()
        {
            Type4[] shooters = FindObjectsOfType(typeof(Type4)) as Type4[];
            foreach (Type4 shooter in shooters)
            {
                if (shooter != null)
                {
                    Instantiate(projectile, shooter.transform.position, Quaternion.identity);
                }
            }

        }
    }
}