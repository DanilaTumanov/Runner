using Runner.Controllers;
using Runner.Managers;
using Runner.SceneObjects.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.SceneObjects
{

    public class PlayerController : BaseSceneObject, ITrapable, IDamagable, IHealable
    {

        public float HP = 500;              // Здоровье игрока
        public float MaxHP = 500;           // Максимальное здоровье игрока
        public float speed = 5;             // Скорость передвижения игрока
        public float jumpForce = 10;        // Сила прыжка
        public float climbingSpeed = 3;     // Скорость вертикального передвижения (например, по лестницам)
        public Trap trap;                   // Префаб ловушки
        public int trapNumber = 5;          // Количество ловушек

        [HideInInspector]
        public bool isGrounded = true;      // Находится ли герой на земле
        [HideInInspector]
        public bool wasGrounded = true;     // Находился ли герой на земле в прошлом кадре

        private Vector2 jumpVector;         // Вектор для указания силы прыжка
        private bool canJump = false;       // Может ли игрок совершить прыжок
        private Transform groundCheck;      // Объект для проверки нахождения на земле
        private Weapon Weapon;              // Скрипт оружия
        private Transform weapon;           // Объект оружия, которое должно быть потомком Hero и называться Weapon
        private Vector2 velocity = Vector2.zero;
        private Animator animator;
                                            


        private bool cheat = false;



        public event Action OnHurt;
        public event Action OnHeal;
        public event Action OnDeath;

        // Use this for initialization
        protected override void Start()
        {
            jumpVector = new Vector2(0f, jumpForce);
            groundCheck = transform.Find("groundCheck");
            weapon = transform.Find("Weapon");
            Weapon = weapon.GetComponentInChildren<Weapon>();
            animator = GetComponent<Animator>();
        }


        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            //if (!Game.Paused)
            //{
                GroundCheck();

                ProcessMovement();

                ProcessJump();

                ProcessPrimaryWeapon();

                if (Input.GetButtonDown("Fire2"))
                {
                    cheat = !cheat;
                }
            //}

        }


        private void LateUpdate()
        {
            ProcessAnimation();

            ProcessMouseControl();
        }



        public void OnGUI()
        {
            // ОТЛАДОЧНАЯ ИНФОРМАЦИЯ
            if (cheat)
                GUI.Box(new Rect(Screen.width - 40, 0, 40, 20), "Cheat");
        }



        private void ProcessAnimation()
        {



        }



        /// <summary>
        /// Обработка движения персонажа
        /// </summary>
        private void ProcessMovement()
        {



            // Устанавливаем вычисленную скорость игрока
            velocity.x = speed;
            velocity.y = Rigidbody.velocity.y;

            // Меняем скорость игрока
            Rigidbody.velocity = velocity;
        }


        /// <summary>
        /// Обработка прыжка
        /// </summary>
        private void ProcessJump()
        {
            // Если игрок находится на земле - значит можно прыгать
            canJump = isGrounded;

            bool jump = InputManager.Jump;

            // Обработка нажатия кнопки прыжка
            if (jump)
            {
                if (canJump)
                {
                    var v = Rigidbody.velocity;
                    v.y = 0;
                    Rigidbody.velocity = v;


                    var jumpVector = this.jumpVector;
                    if (cheat)
                        jumpVector *= 1.3f;


                    Rigidbody.AddForce(jumpVector, ForceMode2D.Impulse);

                    // Пока игрок находится в прыжке, прыгать нельзя
                    canJump = false;
                }
            }
        }


        /// <summary>
        /// Обработка управления мышью
        /// </summary>
        private void ProcessMouseControl()
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mouseWorldPosition.z = weapon.transform.position.z;

            // Ищем угол между направлением вниз и вектором, соединяющим позицию оружия и курсора.
            float angle = Vector3.Angle(Vector2.down, mouseWorldPosition - weapon.position);

            // Поворачиваем оружие на результирующий угол - 90 градусов, т.к. в повороте по оси Z 0 находится на оси X.
            // Не забваем про то, что когда скейл отрицательный (персонаж смотрит влево), нужно умножить результат на -1,
            // Потому что угол поворота учитывает отрицательный скейл.
            weapon.rotation = Quaternion.Euler(0, 0, angle - 90);
        }


        /// <summary>
        /// Обработка действий первичного оружия
        /// </summary>
        private void ProcessPrimaryWeapon()
        {
            if (InputManager.Shoot)
            {
                Weapon.Shoot();
            }
        }



        public void Hurt(float damage)
        {
            if (cheat)
                damage /= 2;

            HP -= damage;

#if UNITY_ANDROID
        Handheld.Vibrate();
#endif

            if (OnHurt != null)
                OnHurt.Invoke();

            if (HP <= 0)
            {
                HP = 0;
                Die();
            }
        }


        private void Die()
        {
            if (OnDeath != null)
                OnDeath.Invoke();
        }


        private void GroundCheck()
        {
            wasGrounded = isGrounded;
            isGrounded = Physics2D.Linecast(transform.position,
                    groundCheck.position,
                    1 << LayerMask.NameToLayer("Ground")
                );
        }

        public void OnTrapEnter(EnvironmentTrap trap)
        {
            if (trap.CompareTag("TrapSpikes"))
            {
                Hurt(trap.damage);
                Rigidbody.velocity = new Vector2(velocity.x, 0f);
                Rigidbody.AddForce(new Vector2(0f, trap.GetComponent<Spikes>().force), ForceMode2D.Impulse);
            }
        }

        public void OnTrapLeave(EnvironmentTrap trap)
        {

        }

        public void Damage(IDamageDealer damageDealer)
        {
            Hurt(damageDealer.GetDamage());
        }

        public void Heal(float healing)
        {
            HP += healing;

            HP = HP > MaxHP ? MaxHP : HP;

            OnHeal.Invoke();
        }
    }


}