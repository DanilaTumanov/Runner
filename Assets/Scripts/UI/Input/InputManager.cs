using Runner.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.Managers
{

    public class InputManager
    {


        public static IInputController InputController;


        public static float HorizontalAxis
        {
            get
            {
                return InputController.HorizontalAxis;
            }
        }

        public static float VerticalAxis
        {
            get
            {
                return InputController.VerticalAxis;
            }
        }

        public static bool Jump
        {
            get
            {
                return InputController.Jump;
            }
        }

        public static bool Shoot
        {
            get
            {
                return InputController.Shoot;
            }
        }

        public static bool PlaceTrap
        {
            get
            {
                return InputController.PlaceTrap;
            }
        }

        public static bool Interact
        {
            get
            {
                return InputController.Interact;
            }
        }

        public static bool Aim
        {
            get
            {
                return InputController.Aim;
            }
        }

        public static Vector2 AimingPosition
        {
            get
            {
                return InputController.AimingPosition;
            }
        }


        // Use this for initialization
        public InputManager()
        {


#if UNITY_ANDROID
            InputController = (new GameObject(name = "InputController")).AddComponent<TouchControl>();
#else
            InputController = (new GameObject("InputController")).AddComponent<PCControl>();
#endif
        }

    }

}
