using Runner.SceneObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects {

	public class RefStaticSceneObject : BaseSceneObject {

        [Tooltip("Объект на сцене, относительно которого данный объект остается статичным. По-умолчанию объект с тегом MainCamera")]
        public Transform reference;

        [Tooltip("Заморозить изменение позиции объекта по X")]
        public bool FreezeX = false;

        [Tooltip("Заморозить изменение позиции объекта по Y")]
        public bool FreezeY = true;


        private Vector3 _delta;

        protected override void Start()
        {
            if(reference == null)
            {
                reference = GameObject.FindGameObjectWithTag("MainCamera").transform;
            }
            
            _delta = transform.position - reference.position;
        }


        protected override void Update()
        {
            transform.position = reference.position + (Vector3) _delta;
        }


    }
	
}