using Runner.SceneObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects {

	public class TimeObjectSpawner : BaseObjectSpawner {


        [Tooltip("Время в секундах до спауна следующего объекта")]
        public float spawnPeriod = 1;

        [Tooltip("Разброс периода спауна (в секундах) в меньшую (X) и большую (Y) сторону. (Числа нужно указывать без знаков)")]
        public Vector2 spawnDispersion = Vector2.zero;

        

        protected override IEnumerator ProcessSpawn()
        {
            while (true)
            {
                Spawn();

                yield return new WaitForSeconds(
                    UnityEngine.Random.Range(
                        spawnPeriod - spawnDispersion.x,
                        spawnPeriod + spawnDispersion.y
                    )
                );
            }
        }

    }
	
}