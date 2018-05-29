using Runner.Controllers;
using Runner.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game3D.UI;
using System.Text;
using Runner.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Runner.Settings {

    [Serializable]
    [CreateAssetMenu(fileName = "ScenesList", menuName = "Runner/Settings/ScenesList")]
    public class ScenesList : ScriptableObject {

        [Header("Сцена основного меню")]
        public SceneInfo mainMenu;
        

        [Header("Сцены игры в порядке следования")]
        [Tooltip("Префаб пользовательского интерфейса для игровых сцен по-умолчанию")]
        public BaseUI defaultGameSceneUI;

        public SceneInfo[] gameScenes;
	}

    [Serializable]
    public struct SceneInfo
    {
        public string title;

        public SceneField scene;

        public BaseUI SceneUIPrefab;
        
        public static implicit operator string(SceneInfo sceenInfo)
        {
            return sceenInfo.scene;
        }

        public override string ToString()
        {
            return this;
        }

    }


#if UNITY_EDITOR
    [CustomEditor(typeof(ScenesList))]
    public class SceneListCustomEditor : Editor
    {

        private ScenesList _target;
        private BaseUI _oldDefaultGameSceneUI;

        private void OnEnable()
        {
            _target = (ScenesList) target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();
            
            for (int i = 0; i < _target.gameScenes.Length; i++)
            {
                _target.gameScenes[i] = SetSceenInfoDefaults(_target.gameScenes[i]);
            }            

            _oldDefaultGameSceneUI = _target.defaultGameSceneUI;
        }


        private SceneInfo SetSceenInfoDefaults(SceneInfo sceenInfo)
        {
            var newInfo = sceenInfo;
            
            if (newInfo.SceneUIPrefab == null || newInfo.SceneUIPrefab == _oldDefaultGameSceneUI)
            {
                newInfo.SceneUIPrefab = _target.defaultGameSceneUI;
            }
            
            newInfo.title = newInfo.scene + (newInfo.scene != String.Empty && sceenInfo.SceneUIPrefab != null ? String.Format(" ({0})", sceenInfo.SceneUIPrefab.name) : String.Empty);
            return newInfo;
        }


    }
#endif


}