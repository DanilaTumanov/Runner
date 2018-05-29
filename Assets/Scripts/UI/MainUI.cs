using Runner.SceneObjects;
using Runner.SceneObjects.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Runner.UI
{

    public class MainUI : MonoBehaviour
    {


        PlayerController hero;
        Weapon primaryWeapon;

        Image primaryWeaponIcon;
        Image primaryWeaponFade;

        // Use this for initialization
        void Start()
        {
            hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<PlayerController>();
            primaryWeapon = hero.GetComponentInChildren<Weapon>();

            primaryWeaponIcon = GameObject.Find("PrimaryWeaponIcon").GetComponent<Image>();
            primaryWeaponFade = GameObject.Find("PrimaryWeaponFade").GetComponent<Image>();

            primaryWeaponIcon.sprite = primaryWeapon.UIicon;
        }


        void LateUpdate()
        {

            // Обновляем состояние UI только после того, как завершился кадр, т.к. нужно учесть все измененные в течение Update состояния

            ProcessPrimaryWeaponStats();

        }


        private void ProcessPrimaryWeaponStats()
        {

        }
    }

}