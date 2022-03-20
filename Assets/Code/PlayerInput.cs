using System;
using UnityEngine;

namespace Code
{
    public class PlayerInput : MonoBehaviour
    {
        public Actions Actions { get; private set; }

        public static PlayerInput Instance;

        private void Awake()
        {
            Instance = this;
            Actions = new Actions();
            Actions.Enable();
        }
        
        private void OnDestroy()
        {
            Actions.Disable();
        }
    }
}