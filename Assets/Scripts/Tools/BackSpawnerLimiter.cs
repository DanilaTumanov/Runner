using Runner.SceneObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.Tools {

	public class BackSpawnerLimiter : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            BaseSceneObject BO = collision.GetComponent<BaseSceneObject>();
            if (BO != null)
            {
                BO.LeavingScene();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            BaseSceneObject BO = collision.GetComponent<BaseSceneObject>();
            if (BO != null)
            {
                BO.LeavedScene();
            }
        }

    }
	
}