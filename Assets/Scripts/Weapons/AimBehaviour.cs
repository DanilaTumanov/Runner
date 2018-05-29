using Runner.Managers;
using Runner.SceneObjects;
using Runner.SceneObjects.Weapons.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects.Weapons
{

	public abstract class AimBehaviour : BaseSceneObject {

        [Tooltip("Префаб прицела")]
        public Sight sight;

        
        private Sight _sightInstance;


        protected override void Start()
        {
            base.Start();
            _sightInstance = Instantiate(sight, GetSightPoint().position, Quaternion.identity, transform);
            _sightInstance.Disable();
        }


        protected override void Update()
        {
            base.Update();
            ProcessAim();
        }



        private void ProcessAim()
        {
            if (InputManager.Aim)
            {
                _sightInstance.Enable();
            }
            else if (_sightInstance.IsEnabled)
            {
                _sightInstance.Disable();
            }
        }


        /// <summary>
        /// Вернет точку из которой целится игрок
        /// </summary>
        /// <returns></returns>
        public abstract Transform GetSightPoint();
    }
	
}