using Runner.SceneObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects {

	public class SpawnedObject : BaseSceneObject {


        #region Свойства

        public Collider2D Collider { get; private set; }

        #endregion



        #region События

        public event Action OnEnteringScene;
        public event Action OnEnteredScene;

        #endregion



        protected override void Start()
        {
            base.Start();

            Collider = GetComponent<Collider2D>();
        }



        public virtual void EnteringScene()
        {
            if (OnEnteringScene != null)
                OnEnteringScene.Invoke();
        }

        public virtual void EnteredScene()
        {
            if (OnEnteredScene != null)
                OnEnteredScene.Invoke();
        }

    }
	
}