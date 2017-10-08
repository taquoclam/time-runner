﻿using System;
using System.Diagnostics;
using UnityEngine;

namespace EnemiesWp
{
    public class EnemiesRock : EnemiesWeapon
    {
        public Rigidbody2D projectile;

        private TimeSpan useDelay = new TimeSpan((long)(TimeSpan.TicksPerSecond * 0.4));
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
            Instantiate(projectile, GameObject.Find("Type3").transform.position, Quaternion.identity);
        }
        
    }
}