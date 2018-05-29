using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Controllers
{

    public class MainCamera : MonoBehaviour {

        private Transform hero;
        private Vector3 camNextPosition;    // Поле для вычисления следующего положения камеры
        private Vector3 camOffset;

        // Use this for initialization
        void Start() {
            hero = GameObject.FindGameObjectWithTag("Hero").transform;

            Camera cam = GetComponent<Camera>();
            float camHeight = cam.orthographicSize;
            float camWidth = cam.aspect * camHeight;

            camOffset = cam.transform.position - hero.position;
            camNextPosition = transform.position;
        }


        void LateUpdate() {
            if (hero != null)
            {
                camNextPosition.x = hero.transform.position.x + camOffset.x;
                camNextPosition.y = transform.position.y;

                transform.position = camNextPosition;
            }
        }

    }
}
