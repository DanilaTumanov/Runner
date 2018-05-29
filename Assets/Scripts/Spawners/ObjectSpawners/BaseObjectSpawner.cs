using Runner.SceneObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects {

	public abstract class BaseObjectSpawner : BaseSceneObject
    {

        [Tooltip("Префаб объекта")]
        public SpawnedObject spawnPrefab;

        [Tooltip("В пассивном режиме спаунер будет создавать объекты только по вызову метода Spawn")]
        public bool passive = false;

        [Tooltip("Время в секундах, определяющее задержку начала работы спаунера")]
        public float spawnDelay = 0;



        protected UnityEngine.Random random = new UnityEngine.Random();


        protected override void Start()
        {
            base.Start();

            if (!passive)
            {
                StartCoroutine(StartSpawn());
            }   
        }



        protected IEnumerator StartSpawn()
        {
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(ProcessSpawn());
        }


        protected abstract IEnumerator ProcessSpawn();



        /// <summary>
        /// Создать объект на сцене
        /// </summary>
        public void Spawn()
        {
            InstantiateFromPool(spawnPrefab, transform.position);
        }

    }
	
}