using Runner.SceneObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.Tools {

	public class FrontSpawnerLimiter : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpawnedObject SO = collision.GetComponent<SpawnedObject>();
            if(SO != null)
            {
                SO.EnteringScene();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            SpawnedObject SO = collision.GetComponent<SpawnedObject>();
            if (SO != null)
            {
                SO.EnteredScene();
            }
        }

    }
	
}