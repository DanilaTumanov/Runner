using Runner.SceneObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects {

    public class DistanceObjectSpawner : BaseObjectSpawner
    {

        [Tooltip("Расстояние в юнитах до спауна следующего объекта")]
        public float spawnDistance = 5;

        [Tooltip("Разброс расстояния спауна (в юнитах) в меньшую (X) и большую (Y) сторону. (Числа нужно указывать без знаков)")]
        public Vector2 spawnDispersion = Vector2.zero;

        [Tooltip("Период проверки соответствия координат. Чем больше период, тем меньше нагрузка, но и меньше точность расстояния")]
        public float checkPeriod = 0.5f;



        private float _lastCoord;



        protected override void Start()
        {
            _lastCoord = transform.position.x;
            base.Start();
        }


        protected override IEnumerator ProcessSpawn()
        {
            float distance = 0;

            while (true)
            {
                if(transform.position.x - _lastCoord > distance)
                {
                    Spawn();
                    distance = GetRandomDistance();
                    _lastCoord = transform.position.x;
                }

                yield return new WaitForSeconds(checkPeriod);
            }
        }


        private float GetRandomDistance()
        {
            return UnityEngine.Random.Range(
                        spawnDistance - spawnDispersion.x,
                        spawnDistance + spawnDispersion.y
                    );
        }
    }

}