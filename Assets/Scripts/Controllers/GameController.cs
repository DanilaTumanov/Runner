using Runner.Managers;
using Runner.SceneObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Runner.Controllers
{

    public class GameController : MonoBehaviour {
        
        Canvas GameUI;
        Canvas PauseScreen;
        Canvas GameOverScreen;
        Text GameOverText;

        PlayerController hero;

        bool paused = false;

        private GameObject _controllerGO;

        public static GameController Instance { get; private set; }

        public static SpawnedObjectsController SpawnedObjectsController { get; private set; }
        public static InputManager InputManager { get; private set; }

        public bool Paused
        {
            get
            {
                return paused;
            }
        }

        

        private void Start()
        {

            Instance = this;

            _controllerGO = new GameObject(name = "Controllers");

            SpawnedObjectsController = _controllerGO.AddComponent<SpawnedObjectsController>();
            InputManager = GameObject.FindGameObjectWithTag("GameUI").GetComponent<InputManager>();

            //GameUI = GameObject.Find("GameUI").GetComponent<Canvas>();
            //PauseScreen = GameObject.Find("PauseScreen").GetComponent<Canvas>();
            //GameOverScreen = GameObject.Find("GameOverScreen").GetComponent<Canvas>();
            //GameOverText = GameObject.Find("GameOverText").GetComponent<Text>();


            hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<PlayerController>();
        
            hero.OnDeath += OnHeroDeath;
        }

    
        private void OnHeroDeath()
        {
            SetGameOverScreen("GAME OVER");
        }


        private void SetGameOverScreen(string text)
        {
            GameOverText.text = text;
            GameOverScreen.enabled = true;
            paused = true;
            Time.timeScale = 0;
        }

    }


}