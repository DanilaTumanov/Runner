using Runner.SceneObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner {

	public class InfiniteStaticDecorationSpawner : BaseSceneObject {

        [SerializeField]
        private SpawnedObject _prefab;

        [Tooltip("Последнее звено, за которым будет спауниться следующее. Обязательно должно быть полностью не левее правого спаун-лимитера")]
        [SerializeField]
        private SpawnedObject _lastChain;


        protected override void Start()
        {
             SpawnNewDecoration();
        }


        private void SpawnNewDecoration()
        {
            Vector3 pos = _lastChain.Position;

            pos.x += _lastChain.Collider.bounds.size.x;

            // TODO: Переделать на пул объектов
            SpawnedObject nextChain = Instantiate(_prefab, pos, Quaternion.identity);

            _lastChain = nextChain;

            _lastChain.OnEnteringScene += SpawnNewDecoration;
        }

    }
	
}