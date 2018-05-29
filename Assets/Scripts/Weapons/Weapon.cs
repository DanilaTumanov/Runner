using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Runner.SceneObjects.Weapons
{

    public class Weapon : AimBehaviour
    {

        public Projectile projectile;
        public float cooldown = 1;
        public Sprite UIicon;

        private Transform barrel;
        private IMovable owner;
        private Vector3 vector0z = new Vector3(0, 0, 0);
        private Vector3 vector180z = new Vector3(0, 0, 180f);
        private float lastShotTime;                               // Время последнего выстрела. Нужно для контроля скорострельности оружия
        protected bool isReloading = false;



        public float LastShotTime { get { return lastShotTime; } }




        // Use this for initialization
        protected override void Start()
        {   
            barrel = transform.Find("Barrel");
            owner = transform.root.GetComponent<IMovable>();
            lastShotTime = Time.time - cooldown;
            base.Start();
        }



        /// <summary>
        /// Произвести выстрел.
        /// </summary>
        /// <returns>Если выстрел был произведен, то вернется true, иначе false</returns>
        public bool Shoot()
        {
            if (!isReloading)
            {

                // Создаем снаряд в координатах ствола (barrel) и с нужным поворотом - поворот снаряда, плюс поворот оружия плюс модификатор
                var proj = Instantiate<Projectile>(projectile, barrel.position, projectile.transform.rotation * transform.rotation);

                // TODO: Дааа... тут криво, конечно.. Нужно выбрать в какой слой положить снаряд, чтобы нормально обрабатывались столкновения
                // Пока не придумал, как сделать это хорошо, да и систему оружия придется подкручивать, когда доделаю выпадающее оружие
                switch (LayerMask.LayerToName(gameObject.layer))
                {
                    case "Hero":
                        proj.gameObject.layer = LayerMask.NameToLayer("Projectiles");
                        break;
                    case "Enemies":
                        proj.gameObject.layer = LayerMask.NameToLayer("EnemyProjectiles");
                        break;
                }

                // Активируем звук выстрела
                GetComponent<AudioSource>().Play();

                lastShotTime = Time.time;

                // Уходим в перезарядку
                isReloading = true;
                Invoke("Reload", cooldown);

                return true;
            }

            return false;
        }



        private void Reload()
        {
            isReloading = false;
        }



        public bool IsReloading()
        {
            return isReloading;
        }


        public override Transform GetSightPoint()
        {
            return barrel;
        }
    }

}