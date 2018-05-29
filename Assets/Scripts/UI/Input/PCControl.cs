using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.UI
{

    public class PCControl : MonoBehaviour, IInputController
    {

        public float HorizontalAxis
        {
            get
            {
                return Input.GetAxis("Horizontal");
            }
        }

        public float VerticalAxis
        {
            get
            {
                return Input.GetAxis("Vertical");
            }
        }

        public bool Jump
        {
            get
            {
                return Input.GetButtonDown("Jump");
            }
        }

        public bool Shoot
        {
            get
            {
                return Input.GetButtonUp("Fire1");
            }
        }

        public bool PlaceTrap
        {
            get
            {
                return Input.GetButtonDown("Fire3");
            }
        }

        public bool Interact
        {
            get
            {
                return Input.GetButtonDown("Interact");
            }
        }


        public bool Aim
        {
            get
            {
                return Input.GetButton("Fire1");
            }
        }


        public Vector2 AimingPosition
        {
            get
            {
                return Input.mousePosition;
            }
        }

    }


}

