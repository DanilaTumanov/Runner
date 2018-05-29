using Runner.SceneObjects;
using Runner.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.Controllers {

	public class SpawnedObjectsController : BaseSceneObject {

        const float LIMITER_COLLIDER_WIDTH = 0.5f;
        const float LIMITER_COLLIDER_HEIGHT = 20f;


        public static float FrontLimit { get; private set; }
        public static float BackLimit { get; private set; }


        protected override void Start()
        {
            PlaceSpawnLimiters();
        }


        private void PlaceSpawnLimiters()
        {
            Camera cam = Camera.main;
            Vector2 camLeftOffset = cam.ViewportToWorldPoint(new Vector2(0, 0.5f));
            Vector2 camRightOffset = cam.ViewportToWorldPoint(new Vector2(1, 0.5f));

            GameObject frontLimiter = new GameObject("FrontLimiter");
            GameObject backLimiter = new GameObject("BackLimiter");

            frontLimiter.transform.parent = transform;
            backLimiter.transform.parent = transform;
            
            frontLimiter.transform.position = camRightOffset;
            backLimiter.transform.position = camLeftOffset;
            
            BoxCollider2D frontBoxCollider = frontLimiter.AddComponent<BoxCollider2D>();
            BoxCollider2D backBoxCollider = backLimiter.AddComponent<BoxCollider2D>();

            frontBoxCollider.isTrigger = true;
            backBoxCollider.isTrigger = true;

            frontBoxCollider.offset = new Vector2(LIMITER_COLLIDER_WIDTH / 2, 0);
            backBoxCollider.offset = new Vector2(- LIMITER_COLLIDER_WIDTH / 2, 0);


            Vector2 size = new Vector2(LIMITER_COLLIDER_WIDTH, LIMITER_COLLIDER_HEIGHT);

            frontBoxCollider.size = size;
            backBoxCollider.size = size;


            frontLimiter.AddComponent<FrontSpawnerLimiter>();
            backLimiter.AddComponent<BackSpawnerLimiter>();

            Rigidbody2D frontRB = frontLimiter.AddComponent<Rigidbody2D>();
            Rigidbody2D backRB = backLimiter.AddComponent<Rigidbody2D>();

            frontRB.isKinematic = true;
            backRB.isKinematic = true;
        }
    }
	
}