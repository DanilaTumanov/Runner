﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.Controllers {
    
	public class MainMenuSceneController : BaseSceneController {

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                print("MainMenuScene switch to SciFi");
                //Main.Instance.SceneManager.LoadGameScene("SciFi");
            }
        }

    }
	
}