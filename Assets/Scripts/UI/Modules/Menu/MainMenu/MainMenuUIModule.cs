using Runner.SceneObjects;
using Runner.UI.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.UI.Modules {

	public class MainMenuUIModule : BaseMenuUIModule {

		private void StartUIButtonHandler()
        {
            Main.Instance.SceneManager.LoadGameScene("RunLevel");
        }

        private void ExitUIButtonHandler()
        {
            Application.Quit();
        }

    }
	
}