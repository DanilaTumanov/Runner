using Runner.Managers;
using Runner.SceneObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects.Weapons.Tools
{

	public class LinearSight : Sight {

        private LineRenderer _lineRenderer;
        private Vector3 _aimPoint;

        protected override void Start()
        {
            base.Start();
            _lineRenderer = GetComponent<LineRenderer>();
            _aimPoint = Vector3.zero;
        }


        protected void LateUpdate()
        {
            UpdateSightLinePosition();
        }



        private void UpdateSightLinePosition()
        {
            _aimPoint = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(InputManager.AimingPosition));
            _aimPoint.z = 0;

            _lineRenderer.SetPosition(1, _aimPoint);
        }
    }
	
}