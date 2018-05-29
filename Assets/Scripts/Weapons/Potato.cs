using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects.Weapons
{

    public class Potato : Projectile
    {


        protected override void Start()
        {
            base.Start();

            rb.AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        }

    }

}