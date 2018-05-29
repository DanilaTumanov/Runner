using Runner.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.SceneObjects
{

    /// <summary>
    /// Базовый класс
    /// </summary>
    public partial class BaseSceneObject : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;


        #region Свойства

        public Rigidbody2D Rigidbody
        {
            get
            {
                return _rigidbody;
            }
        }

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }

            set
            {
                transform.position = value;
            }
        }

        public Vector3 Scale
        {
            get
            {
                return transform.localScale;
            }

            set
            {
                transform.localScale = value;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return transform.rotation;
            }

            set
            {
                transform.rotation = value;
            }
        }

        public Vector3 Velocity
        {
            get
            {
                return Rigidbody != null ? Rigidbody.velocity : Vector2.zero;
            }

            set
            {
                Rigidbody.velocity = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return gameObject.activeInHierarchy;
            }
        }

        #endregion


        #region События

        public event Action OnLeavingScene;
        public event Action OnLeavedScene;

        #endregion




        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        protected virtual void Start()
        {
            
        }


        protected virtual void Update()
        {
            
        }


        public void SetLayer(int layer)
        {
            SetLayer(transform, layer);
        }


        static public void SetLayer(Transform transform, int layer)
        {
            transform.gameObject.layer = layer;

            if (transform.childCount > 0)
            {
                foreach(Transform childTransform in transform)
                {
                    SetLayer(childTransform, layer);
                }
            }
        }


        public virtual void LeavingScene()
        {
            if (OnLeavingScene != null)
                OnLeavingScene.Invoke();
        }

        public virtual void LeavedScene()
        {
            if (OnLeavedScene != null)
                OnLeavedScene.Invoke();

            Destroy(gameObject);
        }


        public void SetEnable(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void Enable()
        {
            SetEnable(true);
        }

        public void Disable()
        {
            SetEnable(false);
        }


        /// <summary>
        /// Метод для создания инстанса из пула.
        /// TODO: Сделать и подключить пул. Пока что будет использоваться обычный Instantiate
        /// </summary>
        /// <param name="prefab">Объект</param>
        /// <param name="position">Позиция</param>
        /// <param name="rotation">Поворот</param>
        /// <param name="parent">Родитель</param>
        protected void InstantiateFromPool(UnityEngine.Object prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            Instantiate(prefab, position, rotation, parent);
        }

        protected void InstantiateFromPool(UnityEngine.Object prefab, Vector3 position, Quaternion rotation)
        {
            InstantiateFromPool(prefab, position, rotation, null);
        }

        protected void InstantiateFromPool(UnityEngine.Object prefab, Vector3 position)
        {
            InstantiateFromPool(prefab, position, Quaternion.identity, null);
        }

    }

}