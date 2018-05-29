using Runner.SceneObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI.Modules
{

    public class LoadScreen : BaseUIModule
    {

        private Image _progressBar;

        protected override void Start()
        {
            _progressBar = transform.Find("ProgressBar").GetComponent<Image>();
            base.Start();
        }

        public void SetProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }
	
    }

}